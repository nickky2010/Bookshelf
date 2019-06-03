using BLL.Interfaces.Localizations.Exceptions;

namespace BLL.Infrastructure.Exceptions.Localizations.English
{
    public class RolesExceptionMessageOnEnglish : IRolesExceptionMessageLocalization
    {
        public string AfterAddNotFound => "Role after add not found!";

        public string InvalidName => "Role not found! Invalid role name intered.";

        public string AlreadyExists(string roleName)
        {
            return $"Role with name {roleName} already exists!";
        }

        public string NotFound(string roleName)
        {
            return $"Role with name {roleName} not found! Perhaps role {roleName} does not exist.";
        }
    }
}
