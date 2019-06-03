using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.Russian
{
    public class UsersExceptionMessageOnRussian : IUsersExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Пользователь после добавления не найден!";

        public string InvalidLoginAndOrPassword => "Пользователь не найден! Возможно был введен неверный логин и/или пароль.";

        public string LoginAlreadyExists(string login)
        {
            return $"Пользователь с логином {login} уже существует!";
        }

        public string СreatingWithRoleIsProhibited(string role)
        {
            return $"Создание пользователя с ролью {role} запрешено!";
        }
    }
}
