using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.Russian
{
    public class RolesExceptionMessageOnRussian : IRolesExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Роль после добавления не найдена!";

        public string InvalidName => "Роль не найдена! Введено неверное имя роли.";

        public string AlreadyExists(string roleName)
        {
            return $"Роль с именем {roleName} уже существует!";
        }

        public string NotFound(string roleName)
        {
            return $"Роль с именем {roleName} не найдена! Возможно роли с именем {roleName} не существует.";
        }
    }
}
