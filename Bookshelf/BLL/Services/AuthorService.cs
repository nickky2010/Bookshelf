using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Interfaces.Localizations.Exceptions;
using DAL.EF.Contexts;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthorService : IDataBaseService<AuthorDTO>
    {
        IUnitOfWork<BookshelfContext> UnitOfWork { get; set; }
        public IUnitOfWorkExceptionMessageLocalization UnitOfWorkExceptionMessage { get; private set; }
        public AuthorService(IUnitOfWorkService unitOfWorkService, IUnitOfWorkExceptionMessageLocalization unitOfWorkExceptionMessageLocalization)
        {
            UnitOfWork = unitOfWorkService.GetIUnitOfWorkBookshelfContext();
            UnitOfWorkExceptionMessage = unitOfWorkExceptionMessageLocalization;
        }

        public async Task<ICollection<AuthorDTO>> GetPageAsync(int startItem, int countItem)
        {
            ICollection <AuthorDTO> authorDTOs = 
                Mapper.Map<ICollection<Author>, List<AuthorDTO>>(await UnitOfWork.Authors.GetPageAsync(startItem, countItem));
            if (authorDTOs.Count!=0)
            {
                foreach (AuthorDTO item in authorDTOs)
                {
                    await FillItem(item);
                }
                return authorDTOs;
            }
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.AuthorsException.NotFound);
        }

        public async Task<AuthorDTO> GetAsync(int id)
        {
            AuthorDTO authorDTO = Mapper.Map<Author, AuthorDTO>(await UnitOfWork.Authors.GetAsync(i => i.Id == id));
            if (authorDTO != null)
            {
                await FillItem(authorDTO);
                return authorDTO;
            }
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.AuthorsException.NotFoundById(id));
        }

        public async Task<AuthorDTO> AddAsync(IEntityDTO ientityDTO)
        {
            AuthorDTO authorDTO = (AuthorDTO)ientityDTO;
            UnitOfWork.Authors.AddAsync(Mapper.Map<AuthorDTO, Author>(authorDTO));
            await UnitOfWork.SaveChangesAsync();
            Author author = await UnitOfWork.Authors.GetLastItemAsync();
            if (author != null)
                return Mapper.Map<Author, AuthorDTO>(author);
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.AuthorsException.AfterAddNotFound);
        }

        public async Task<AuthorDTO> UpdateAsync(IEntityDTO ientityDTO)
        {
            AuthorDTO authorDTO = (AuthorDTO)ientityDTO;
            Author author = await UnitOfWork.Authors.GetAsync(i => i.Id == authorDTO.Id);
            if (author != null)
            {
                Mapper.Map(authorDTO, author);
                UnitOfWork.Authors.Update(author);
                await UnitOfWork.SaveChangesAsync();
                return await GetAsync(author.Id);
            }
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.AuthorsException.NotFoundById(authorDTO.Id));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Author author = await UnitOfWork.Authors.GetAsync(i => i.Id == id);
            if (author != null)
            {
                UnitOfWork.BookAuthors.DeleteRange(await UnitOfWork.BookAuthors.GetAllAsync(a => a.AuthorId == author.Id));
                await UnitOfWork.SaveChangesAsync();
                UnitOfWork.Authors.Delete(author);
                await UnitOfWork.SaveChangesAsync();
                return true;
            }
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.AuthorsException.UnableToDelete(id));
        }

        private async Task FillItem(AuthorDTO authorDTO)
        {
            ICollection<BookAuthor> bookAuthors = await UnitOfWork.BookAuthors.GetAllAsync(i => i.AuthorId == authorDTO.Id);
            if (bookAuthors != null)
            {
                foreach (BookAuthor item in bookAuthors)
                {
                    authorDTO.Books.Add(Mapper.Map<Book, BookDTO>(await UnitOfWork.Books.GetAsync(i => i.Id == item.BookId)));
                }
            }
        }
    }
}
