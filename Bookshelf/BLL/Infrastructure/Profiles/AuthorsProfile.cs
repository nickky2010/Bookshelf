using AutoMapper;
using BLL.DTO;
using DAL.Models;

namespace BLL.Infrastructure.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
        }
    }
}
