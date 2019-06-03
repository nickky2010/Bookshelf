namespace BLL.Interfaces.Localizations.Exceptions
{
    public interface IBaseExceptionMessageLocalization
    {
        string AfterAddNotFound { get; }
        string NotFound { get; }
        string NotFoundById(int id);
        string UnableToDelete(int id);
    }
}
