using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.EF.Contexts;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using BLL.DTO.Report;
using BLL.Infrastructure.Extensions;
using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Services
{
    public class ReportService : IReportService
    {
        IUnitOfWork<BookshelfContext> UnitOfWork { get; set; }
        public IUnitOfWorkExceptionMessageLocalization UnitOfWorkExceptionMessage { get; private set; }
        public ReportService(IUnitOfWorkService unitOfWorkService, IUnitOfWorkExceptionMessageLocalization unitOfWorkExceptionMessageLocalization)
        {
            UnitOfWork = unitOfWorkService.GetIUnitOfWorkBookshelfContext();
            UnitOfWorkExceptionMessage = unitOfWorkExceptionMessageLocalization;
        }

        public async Task<ICollection<BookDTO>> GetBooksByPublicationDateAsync(int startYear, int endYear, string columnNameForSort)
        {
            ICollection<BookDTO> bookDTOs =
               Mapper.Map<ICollection<Book>, List<BookDTO>>(await UnitOfWork.Books.GetAllAsync(b=>b.Year>=startYear && b.Year<=endYear));
            if (bookDTOs.Count != 0)
                return bookDTOs.OrderByShell(columnNameForSort).ToList();
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.BooksException.NotFound);
        }
        public async Task<ICollection<AuthorDTO>> AuthorsWithOneOrWithoutPublishedBooksAsync(string columnNameForSort)
        {
            ICollection<AuthorDTO> authorDTOs =
               Mapper.Map<ICollection<Author>, List<AuthorDTO>>(await UnitOfWork.Authors.GetAllAsync(b=> b.BookAuthors.Count()<2));
            if (authorDTOs.Count != 0)
                return authorDTOs.OrderByShell(columnNameForSort).ToList();
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.AuthorsException.NotFound);
        }
        public async Task<IEnumerable<AuthorPopularityDTO>> GetAuthorsByPopularityAsync(string columnNameForSort)
        {
            ICollection<Author> authors = await UnitOfWork.Authors.GetAllAsync();
            List<AuthorPopularityDTO> authorPopularityDTOs = new List<AuthorPopularityDTO>();
            var query = authors.Select(a => new
            {
                a.FirstName,
                a.LastName,
                BooksForPopularity = authors.Max(aa => aa.BookAuthors.Count()) - a.BookAuthors.Count() + 1
            })
            .ToList();
            foreach (var item in query)
            {
                authorPopularityDTOs.Add(new AuthorPopularityDTO
                {
                    LastName = item.LastName,
                    FirstName = item.FirstName,
                    BooksForPopularity = item.BooksForPopularity
                });
            }
            if (authorPopularityDTOs.Count != 0)
            {
                return authorPopularityDTOs.OrderByShell("BooksForPopularity").ToList();
            }
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.AuthorsException.NotFound);
        }
        public async Task<IEnumerable<PublishingHouseDTO>> GetPublishingHousesWhereAuthorNotPublishedAsync(string authorLastname, string columnNameForSort)
        {
            var publishingHouses = await UnitOfWork.PublishingHouses.GetAllAsync();
            var books = await UnitOfWork.Books.GetAllAsync();
            var bookAuthors = await UnitOfWork.BookAuthors.GetAllAsync();
            var authors = await UnitOfWork.Authors.GetAllAsync();
            List<PublishingHouseDTO> publishingHouseDTOs =
                Mapper.Map<IEnumerable<PublishingHouse>, List<PublishingHouseDTO>>(publishingHouses
                .Where(x => !publishingHouses
                .Join(books, p => p.Id, b => b.PublishingHouseId, (p, b) => new
                {
                    PublishingHouseId = p.Id,
                    IdBook = b.Id,
                    p.Name
                })
                .Join(bookAuthors, p => p.IdBook, ba => ba.BookId, (p, ba) => new
                {
                    ba.AuthorId,
                    p.PublishingHouseId,
                    p.Name
                })
                .Join(authors, p => p.AuthorId, a => a.Id, (p, a) => new
                {
                    a.LastName,
                    p.PublishingHouseId,
                    p.Name
                })
                .Where(a => a.LastName == authorLastname)
                .ToList()
                .Exists(p => p.PublishingHouseId == x.Id))
                .ToList());         
                //.OrderByBubble(delegate (PublishingHouse p1, PublishingHouse p2) { return p1.Name.CompareTo(p2.Name); }));
            if (publishingHouseDTOs.Count != 0)
                return publishingHouseDTOs.OrderByShell(columnNameForSort).ToList();
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.PublishingHousesException.NotFound);
        }
    }
}

