namespace BLL.Interfaces.Localizations.Exceptions
{
    public interface IUsersExceptionMessageLocalization
    {
        string AfterAddNotFound { get; }
        string InvalidLoginAndOrPassword { get; }
        string LoginAlreadyExists(string login);
        string СreatingWithRoleIsProhibited(string role);
    }
}