using BLL.DTO;
using BLL.DTO.Report;
using BLL.Interfaces.Localizations.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IReportService
    {
        IUnitOfWorkExceptionMessageLocalization UnitOfWorkExceptionMessage { get; }
        Task<ICollection<BookDTO>> GetBooksByPublicationDateAsync(int startYear, int endYear, string columnNameForSort);
        Task<ICollection<AuthorDTO>> AuthorsWithOneOrWithoutPublishedBooksAsync(string columnNameForSort);
        Task<IEnumerable<AuthorPopularityDTO>> GetAuthorsByPopularityAsync(string columnNameForSort);
        Task<IEnumerable<PublishingHouseDTO>> GetPublishingHousesWhereAuthorNotPublishedAsync(string authorLastname, string columnNameForSort);
    }
}
