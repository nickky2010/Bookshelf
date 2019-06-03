using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.English
{
    public class UsersExceptionMessageOnEnglish : IUsersExceptionMessageLocalization
    {
        public string AfterAddNotFound => "User after add not found!";

        public string InvalidLoginAndOrPassword => "User not found! Invalid login and / or password intered.";

        public string LoginAlreadyExists(string login)
        {
            return $"User with login {login} already exists!";
        }

        public string СreatingWithRoleIsProhibited(string role)
        {
            return $"Сreating a user with a role {role} is prohibited!";
        }
    }
}
