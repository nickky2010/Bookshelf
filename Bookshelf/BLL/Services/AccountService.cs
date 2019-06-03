using AutoMapper;
using BLL.DTO.Identity;
using BLL.Interfaces;
using BLL.Interfaces.Localizations.Exceptions;
using DAL.EF.Contexts;
using DAL.Interfaces;
using DAL.Models.Identity;
using System.Threading.Tasks;

namespace BLL.Services.Identity
{
    public class AccountService : IAccountService
    {
        IUnitOfWork<BookshelfContext> UnitOfWork { get; set; }
        public IUnitOfWorkExceptionMessageLocalization UnitOfWorkExceptionMessage { get; private set; }
        public AccountService(IUnitOfWorkService unitOfWorkService, IUnitOfWorkExceptionMessageLocalization unitOfWorkExceptionMessageLocalization)
        {
            UnitOfWork = unitOfWorkService.GetIUnitOfWorkBookshelfContext();
            UnitOfWorkExceptionMessage = unitOfWorkExceptionMessageLocalization;
        }
        public async Task<UserDTO> GetUserAsync(UserViewModel userViewModel)
        {
            UserDTO userDto = Mapper.Map<User, UserDTO>(await UnitOfWork.Users.GetAsync(u => 
                u.Login == userViewModel.Login && u.Password == userViewModel.Password));
            if (userDto != null)
                return userDto;
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.UsersException.InvalidLoginAndOrPassword);
        }

        public async Task<RoleDTO> GetRoleAsync(string roleName)
        {
            RoleDTO roleDTO = Mapper.Map<Role, RoleDTO>(await UnitOfWork.Roles.GetAsync(r => r.Name == roleName));
            if (roleDTO != null)
                return roleDTO;
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.RolesException.InvalidName);
        }

        public async Task<UserDTO> AddUserAsync(UserViewModel userViewModel)
        {
            User user = Mapper.Map<UserViewModel, User>(userViewModel);
            Role role = await UnitOfWork.Roles.GetAsync(r => r.Name == userViewModel.Role.Name);
            if (role != null)
            {
                user.RoleId = role.Id;
                user.Role = null;
            }
            else
                throw new BadRequestException(UnitOfWorkExceptionMessage.RolesException.NotFound(userViewModel.Role.Name));
            User userCheck = await UnitOfWork.Users.GetAsync(u => u.Login == userViewModel.Login);
            if (userCheck==null)
            {
                UnitOfWork.Users.AddAsync(user);
                await UnitOfWork.SaveChangesAsync();
                user = await UnitOfWork.Users.GetLastItemAsync();
                if (user != null)
                    return Mapper.Map<User, UserDTO>(user);
                else
                    throw new NotFoundException(UnitOfWorkExceptionMessage.UsersException.AfterAddNotFound);
            }
            else
                throw new BadRequestException(UnitOfWorkExceptionMessage.UsersException.LoginAlreadyExists(userViewModel.Login));
        }
        public async Task<RoleDTO> AddRoleAsync(RoleViewModel roleViewModel)
        {
            Role role = await UnitOfWork.Roles.GetAsync(r => r.Name == roleViewModel.Name);
            if (role != null)
                throw new BadRequestException(UnitOfWorkExceptionMessage.RolesException.AlreadyExists(roleViewModel.Name));
            else
            {
                UnitOfWork.Roles.AddAsync(Mapper.Map<RoleViewModel, Role>(roleViewModel));
                await UnitOfWork.SaveChangesAsync();
            }
            await UnitOfWork.SaveChangesAsync();
            role = await UnitOfWork.Roles.GetLastItemAsync();
            if (role != null)
                return Mapper.Map<Role, RoleDTO>(role);
            else
                throw new NotFoundException(UnitOfWorkExceptionMessage.RolesException.AfterAddNotFound);
        }
    }
}
