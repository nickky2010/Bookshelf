using AutoMapper;
using BLL.DTO.ViewModel;
using DAL.Models;

namespace BLL.Infrastructure.Profiles
{
    public class AuthorsViewModelProfile : Profile
    {
        public AuthorsViewModelProfile()
        {
            CreateMap<Author, AuthorViewModel>().ReverseMap();
        }
    }
}
