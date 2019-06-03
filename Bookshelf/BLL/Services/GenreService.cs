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
    public class GenreService : IDataBaseService<GenreDTO>
    {
        IUnitOfWork<BookshelfContext> UnitOfWork { get; set; }
        public IUnitOfWorkExceptionMessageLocalization UnitOfWorkExceptionMessage { get; private set; }
        public GenreService(IUnitOfWorkService unitOfWorkService, IUnitOfWorkExceptionMessageLocalization unitOfWorkExceptionMessageLocalization)
        {
            UnitOfWork = unitOfWorkService.GetIUnitOfWorkBookshelfContext();
            UnitOfWorkExceptionMessage = unitOfWorkExceptionMessageLocalization;
        }

        public async Task<ICollection<GenreDTO>> GetPageAsync(int startItem, int countItem)
        {
            ICollection<GenreDTO> genreDTOs = Mapper.Map<ICollection<Genre>, List<GenreDTO>>(await UnitOfWork.Genres.GetPageAsync(startItem, countItem));
            if (genreDTOs.Count != 0)
            {
                foreach (GenreDTO item in genreDTOs)
                {
                    await FillItem(item);
                }
                return genreDTOs;
            }
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.GenresException.NotFound);
        }

        public async Task<GenreDTO> GetAsync(int id)
        {
            GenreDTO genreDTO = Mapper.Map<Genre, GenreDTO>(await UnitOfWork.Genres.GetAsync(i => i.Id == id));
            if (genreDTO != null)
            {
                await FillItem(genreDTO);
                return genreDTO;
            }
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.GenresException.NotFoundById(id));
        }

        public async Task<GenreDTO> AddAsync(IEntityDTO ientityDTO)
        {
            GenreDTO genreDTO = (GenreDTO)ientityDTO;
            UnitOfWork.Genres.AddAsync(Mapper.Map<GenreDTO, Genre>(genreDTO));
            await UnitOfWork.SaveChangesAsync();
            Genre genre = await UnitOfWork.Genres.GetLastItemAsync();
            if (genre != null)
                return Mapper.Map<Genre, GenreDTO>(genre);
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.GenresException.AfterAddNotFound);
        }

        public async Task<GenreDTO> UpdateAsync(IEntityDTO ientityDTO)
        {
            GenreDTO genreDTO = (GenreDTO)ientityDTO;
            Genre genre = await UnitOfWork.Genres.GetAsync(i => i.Id == genreDTO.Id);
            if (genre != null)
            {
                Mapper.Map(genreDTO, genre);
                UnitOfWork.Genres.Update(genre);
                await UnitOfWork.SaveChangesAsync();
                return await GetAsync(genre.Id);
            }
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.GenresException.NotFoundById(genreDTO.Id));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Genre genre = await UnitOfWork.Genres.GetAsync(i => i.Id == id);
            if (genre != null)
            {
                UnitOfWork.BookGenres.DeleteRange(await UnitOfWork.BookGenres.GetAllAsync(b => b.GenreId == genre.Id));
                await UnitOfWork.SaveChangesAsync();
                UnitOfWork.Genres.Delete(genre);
                await UnitOfWork.SaveChangesAsync();
                return true;
            }
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.GenresException.UnableToDelete(id));
        }

        private async Task FillItem(GenreDTO genreDTO)
        {
            ICollection<BookGenre> bookGenres = await UnitOfWork.BookGenres.GetAllAsync(i => i.GenreId == genreDTO.Id);
            if (bookGenres != null)
            {
                foreach (BookGenre item in bookGenres)
                {
                    genreDTO.Books.Add(Mapper.Map<Book, BookDTO>(await UnitOfWork.Books.GetAsync(i => i.Id == item.BookId)));
                }
            }
        }
    }
}
