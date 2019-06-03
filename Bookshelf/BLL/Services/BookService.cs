using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DAL.EF.Contexts;
using BLL.DTO.ViewModel;
using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Services
{
    public class BookService : IDataBaseService<BookDTO>
    {
        IUnitOfWork<BookshelfContext> UnitOfWork { get; set; }
        public IUnitOfWorkExceptionMessageLocalization UnitOfWorkExceptionMessage { get; private set; }
        public BookService(IUnitOfWorkService unitOfWorkService, IUnitOfWorkExceptionMessageLocalization unitOfWorkExceptionMessageLocalization)
        {
            UnitOfWork = unitOfWorkService.GetIUnitOfWorkBookshelfContext();
            UnitOfWorkExceptionMessage = unitOfWorkExceptionMessageLocalization;
        }

        public async Task<ICollection<BookDTO>> GetPageAsync(int startItem, int countItem)
        {
            ICollection<BookDTO> bookDTOs =
                Mapper.Map<ICollection<Book>, List<BookDTO>>(await UnitOfWork.Books.GetPageAsync(startItem, countItem));
            if (bookDTOs.Count != 0)
                return bookDTOs;
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.BooksException.NotFound);
        }

        public async Task<BookDTO> GetAsync(int id)
        {
            BookDTO bookDTO = Mapper.Map<Book, BookDTO>(await UnitOfWork.Books.GetAsync(i => i.Id == id));
            if (bookDTO != null)
                return bookDTO;
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.BooksException.NotFoundById(id));
        }

        public async Task<BookDTO> AddAsync(IEntityDTO ientityDTO)
        {
            BookViewModel bookViewModel = (BookViewModel)ientityDTO;
            Book book = Mapper.Map<BookViewModel, Book>(bookViewModel);
            BookGroup bookGroup = await UnitOfWork.BookGroups.GetAsync(bg => bg.Id == book.BookGroup.Id);
            if (bookGroup != null)
            {
                book.BookGroupId = bookGroup.Id;
                book.BookGroup = null;
            }
            else
                throw new BadRequestException(UnitOfWorkExceptionMessage.BookGroupsException.NotFoundById(book.BookGroup.Id));
            Language language = await UnitOfWork.Languages.GetAsync(l => l.Name == book.Language.Name);
            if (language != null)
            {
                book.LanguageId = language.Id;
                book.Language = null;
            }
            else
                throw new BadRequestException(UnitOfWorkExceptionMessage.LanguagesException.NotFoundByName(book.Language.Name));
            PublishingHouse publishingHouse = await UnitOfWork.PublishingHouses.GetAsync(p => p.Name == book.PublishingHouse.Name);
            if (publishingHouse != null)
            {
                book.PublishingHouseId = publishingHouse.Id;
                book.PublishingHouse = null;
            }
            else
                throw new BadRequestException(UnitOfWorkExceptionMessage.PublishingHousesException.NotFoundByName(book.PublishingHouse.Name));
            Series series = await UnitOfWork.Series.GetAsync(s => s.Name == book.Series.Name);
            if (series != null)
            {
                book.SeriesId = series.Id;
                book.Series = null;
            }
            else
                throw new BadRequestException(UnitOfWorkExceptionMessage.SeriesException.NotFoundByName(book.Series.Name));
            UnitOfWork.Books.AddAsync(book);
            await UnitOfWork.SaveChangesAsync();
            book = await UnitOfWork.Books.GetLastItemAsync();
            if (book != null)
            {
                if (bookViewModel.Authors.Count != 0)
                {
                    ICollection<BookAuthor> bookAuthors = new List<BookAuthor>();
                    foreach (AuthorViewModel item in bookViewModel.Authors)
                    {
                        Author author = await UnitOfWork.Authors.GetAsync(a => a.Id == item.Id);
                        if (author != null)
                            bookAuthors.Add(new BookAuthor { BookId = book.Id, AuthorId = item.Id });
                        else
                            throw new BadRequestException(UnitOfWorkExceptionMessage.AuthorsException.NotFoundById(item.Id));
                    }
                    UnitOfWork.BookAuthors.AddRangeAsync(bookAuthors);
                }
                if (bookViewModel.Genres.Count != 0)
                {
                    ICollection<BookGenre> bookGenres = new List<BookGenre>();
                    foreach (GenreViewModel item in bookViewModel.Genres)
                    {
                        Genre genre = await UnitOfWork.Genres.GetAsync(a => a.Id == item.Id);
                        if (genre != null)
                            bookGenres.Add(new BookGenre { BookId = book.Id, GenreId = item.Id });
                        else
                            throw new BadRequestException(UnitOfWorkExceptionMessage.GenresException.NotFoundById(item.Id));
                    }
                    UnitOfWork.BookGenres.AddRangeAsync(bookGenres);
                }
                if (bookViewModel.Tags.Count != 0)
                {
                    ICollection<BookTag> bookTags = new List<BookTag>();
                    foreach (TagViewModel item in bookViewModel.Tags)
                    {
                        Tag tag = await UnitOfWork.Tags.GetAsync(a => a.Id == item.Id);
                        if (tag != null)
                            bookTags.Add(new BookTag { BookId = book.Id, TagId = item.Id });
                        else
                            throw new BadRequestException(UnitOfWorkExceptionMessage.TagsException.NotFoundById(item.Id));
                    }
                    UnitOfWork.BookTags.AddRangeAsync(bookTags);
                }
                await UnitOfWork.SaveChangesAsync();
                return await GetAsync(book.Id);
            }
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.BooksException.AfterAddNotFound);
        }

        public async Task<BookDTO> UpdateAsync(IEntityDTO ientityDTO)
        {
            BookViewModel bookViewModel = (BookViewModel)ientityDTO;
            Book book = await UnitOfWork.Books.GetAsync(i => i.Id == bookViewModel.Id);
            if (book != null)
            {
                Mapper.Map(bookViewModel, book);
                UnitOfWork.Books.Update(book);
                if (bookViewModel.Authors.Count != 0)
                {
                    ICollection<BookAuthor> bookAuthors = await UnitOfWork.BookAuthors.GetAllAsync(ba => ba.BookId == bookViewModel.Id);
                    ICollection<BookAuthor> existBookAuthors = new List<BookAuthor>();
                    foreach (BookAuthor bookAuthor in bookAuthors)
                    {
                        bool exist = false;
                        foreach (AuthorViewModel author in bookViewModel.Authors)
                        {
                            if (bookAuthor.AuthorId == author.Id)
                            {
                                exist = true;
                                break;
                            }
                        }
                        if (exist)
                            existBookAuthors.Add(bookAuthor);
                    }
                    foreach (BookAuthor item in existBookAuthors)
                    {
                        bookAuthors.Remove(item);
                    }
                    if(bookAuthors.Count!=0)
                        foreach (BookAuthor item in bookAuthors)
                        {
                            UnitOfWork.BookAuthors.Delete(o=>o.AuthorId==item.AuthorId && o.BookId==item.BookId);
                        }
                    foreach (BookAuthor bookAuthor in existBookAuthors)
                    {
                        bookViewModel.Authors.Remove(bookViewModel.Authors.First(a => a.Id == bookAuthor.AuthorId));
                    }
                    if (bookViewModel.Authors.Count != 0)
                    {
                        foreach (AuthorViewModel author in bookViewModel.Authors)
                        {
                            if (await UnitOfWork.Authors.GetAsync(a => a.Id == author.Id) != null)
                                UnitOfWork.BookAuthors.AddAsync(new BookAuthor { AuthorId = author.Id, BookId = bookViewModel.Id });
                            else
                                throw new BadRequestException(UnitOfWorkExceptionMessage.AuthorsException.NotFoundById(author.Id));
                        }
                    }
                }
                else
                    UnitOfWork.BookAuthors.Delete(a=>a.BookId == bookViewModel.Id);
                if (bookViewModel.Genres.Count != 0)
                {
                    ICollection<BookGenre> bookGenres = await UnitOfWork.BookGenres.GetAllAsync(ba => ba.BookId == bookViewModel.Id);
                    ICollection<BookGenre> existBookGenres = new List<BookGenre>();
                    foreach (BookGenre bookGenre in bookGenres)
                    {
                        bool exist = false;
                        foreach (GenreViewModel genre in bookViewModel.Genres)
                        {
                            if (bookGenre.GenreId == genre.Id)
                            {
                                exist = true;
                                break;
                            }
                        }
                        if (exist)
                            existBookGenres.Add(bookGenre);
                    }
                    foreach (BookGenre item in existBookGenres)
                    {
                        bookGenres.Remove(item);
                    }
                    if (bookGenres.Count != 0)
                        foreach (BookGenre item in bookGenres)
                        {
                            UnitOfWork.BookGenres.Delete(o => o.GenreId == item.GenreId && o.BookId == item.BookId);
                        }
                    foreach (BookGenre bookGenre in existBookGenres)
                    {
                        bookViewModel.Genres.Remove(bookViewModel.Genres.First(a => a.Id == bookGenre.GenreId));
                    }
                    if (bookViewModel.Genres.Count != 0)
                    {
                        foreach (GenreViewModel genre in bookViewModel.Genres)
                        {
                            if (await UnitOfWork.Genres.GetAsync(a => a.Id == genre.Id) != null)
                                UnitOfWork.BookGenres.AddAsync(new BookGenre { GenreId = genre.Id, BookId = bookViewModel.Id });
                            else
                                throw new BadRequestException(UnitOfWorkExceptionMessage.GenresException.NotFoundById(genre.Id));
                        }
                    }
                }
                else
                    UnitOfWork.BookAuthors.Delete(a => a.BookId == bookViewModel.Id);
                if (bookViewModel.Tags.Count != 0)
                {
                    ICollection<BookTag> bookTags = await UnitOfWork.BookTags.GetAllAsync(ba => ba.BookId == bookViewModel.Id);
                    ICollection<BookTag> existBookTags = new List<BookTag>();
                    foreach (BookTag bookTag in bookTags)
                    {
                        bool exist = false;
                        foreach (TagViewModel tag in bookViewModel.Tags)
                        {
                            if (bookTag.TagId == tag.Id)
                            {
                                exist = true;
                                break;
                            }
                        }
                        if (exist)
                            existBookTags.Add(bookTag);
                    }
                    foreach (BookTag item in existBookTags)
                    {
                        bookTags.Remove(item);
                    }
                    if (bookTags.Count != 0)
                        foreach (BookTag item in bookTags)
                        {
                            UnitOfWork.BookTags.Delete(o => o.TagId == item.TagId && o.BookId == item.BookId);
                        }
                    foreach (BookTag bookTag in existBookTags)
                    {
                        bookViewModel.Tags.Remove(bookViewModel.Tags.First(a => a.Id == bookTag.TagId));
                    }
                    if (bookViewModel.Tags.Count != 0)
                    {
                        foreach (TagViewModel tag in bookViewModel.Tags)
                        {
                            if (await UnitOfWork.Tags.GetAsync(a => a.Id == tag.Id) != null)
                                UnitOfWork.BookTags.AddAsync(new BookTag { TagId = tag.Id, BookId = bookViewModel.Id });
                            else
                                throw new BadRequestException(UnitOfWorkExceptionMessage.TagsException.NotFoundById(tag.Id));
                        }
                    }
                }
                else
                    UnitOfWork.BookTags.Delete(a => a.BookId == bookViewModel.Id);
                await UnitOfWork.SaveChangesAsync();
                return await GetAsync(book.Id);
            }
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.BooksException.NotFoundById(bookViewModel.Id));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Book book = await UnitOfWork.Books.GetAsync(i => i.Id == id);
            if (book != null)
            {
                UnitOfWork.BookInformation.Delete(await UnitOfWork.BookInformation.GetAsync(b => b.BookId == book.Id));
                UnitOfWork.BookAuthors.DeleteRange(await UnitOfWork.BookAuthors.GetAllAsync(b => b.BookId == book.Id));
                UnitOfWork.BookGenres.DeleteRange(await UnitOfWork.BookGenres.GetAllAsync(b => b.BookId == book.Id));
                UnitOfWork.BookTags.DeleteRange(await UnitOfWork.BookTags.GetAllAsync(b => b.BookId == book.Id));
                await UnitOfWork.SaveChangesAsync();
                UnitOfWork.Books.Delete(book);
                await UnitOfWork.SaveChangesAsync();
                return true;
            }
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.BooksException.UnableToDelete(id));
        }
    }
}
