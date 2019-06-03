using BLL.DTO.Identity;
using BLL.Interfaces.Localizations.Exceptions;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        IUnitOfWorkExceptionMessageLocalization UnitOfWorkExceptionMessage { get; }
        Task<UserDTO> GetUserAsync(UserViewModel userViewModel);
        Task<RoleDTO> GetRoleAsync(string roleName);
        Task<UserDTO> AddUserAsync(UserViewModel userViewModel);
        Task<RoleDTO> AddRoleAsync(RoleViewModel roleViewModel);
    }
}

