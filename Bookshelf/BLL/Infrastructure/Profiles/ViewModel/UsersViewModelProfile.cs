using AutoMapper;
using BLL.DTO.Identity;
using DAL.Models.Identity;

namespace BLL.Infrastructure.Profiles
{
    public class UsersViewModelProfile : Profile
    {
        public UsersViewModelProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForPath(dest => dest.Role, opts => opts.MapFrom(m => m.Role.Id));
            CreateMap<UserViewModel, User>()
                .ForPath(dest => dest.Role.Id, opts => opts.MapFrom(m => m.Role));
        }
    }
}
