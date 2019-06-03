namespace BLL.Interfaces.Localizations.Exceptions
{
    public interface IUnitOfWorkExceptionMessageLocalization
    {
        IAuthorsExceptionMessageLocalization AuthorsException { get; }
        IBooksExceptionMessageLocalization BooksException { get; }
        IGenresExceptionMessageLocalization GenresException { get; }
        ITagsExceptionMessageLocalization TagsException { get; }
        IUsersExceptionMessageLocalization UsersException { get; }
        IRolesExceptionMessageLocalization RolesException { get; }
        IBookGroupsExceptionMessageLocalization BookGroupsException { get; }
        ILanguagesExceptionMessageLocalization LanguagesException { get; }
        IPublishingHousesExceptionMessageLocalization PublishingHousesException { get; }
        ISeriesExceptionMessageLocalization SeriesException { get; }
        IDataExceptionMessageLocalization DataException { get; }
        IReportExceptionMessageLocalization ReportException { get; }
        IDbUpdateConcurrencyExceptionMessageLocalization DbUpdateConcurrencyException { get; }
    }
}
