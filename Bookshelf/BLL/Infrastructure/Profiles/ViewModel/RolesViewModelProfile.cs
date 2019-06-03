using AutoMapper;
using BLL.DTO.Identity;
using DAL.Models.Identity;

namespace BLL.Infrastructure.Profiles
{
    public class RolesViewModelProfile : Profile
    {
        public RolesViewModelProfile()
        {
            CreateMap<Role, RoleViewModel>().ReverseMap();
        }
    }
}
