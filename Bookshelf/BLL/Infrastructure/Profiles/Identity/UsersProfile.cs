using AutoMapper;
using BLL.DTO.Identity;
using DAL.Models.Identity;

namespace BLL.Infrastructure.Profiles.Identity
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserDTO>()
                .ForPath(dest => dest.Role.Id, opts => opts.MapFrom(m => m.RoleId))
                .ForPath(dest => dest.Role.Name, opts => opts.MapFrom(m => m.Role.Name))
                .ReverseMap();
        }
    }
}
