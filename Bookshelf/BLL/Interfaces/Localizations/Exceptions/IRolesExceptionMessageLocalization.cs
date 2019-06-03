namespace BLL.Interfaces.Localizations.Exceptions
{
    public interface IRolesExceptionMessageLocalization
    {
        string AfterAddNotFound { get; }
        string InvalidName { get; }
        string AlreadyExists(string roleName);
        string NotFound(string roleName);
    }
}