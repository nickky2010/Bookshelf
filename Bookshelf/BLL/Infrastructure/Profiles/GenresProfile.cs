using AutoMapper;
using BLL.DTO;
using DAL.Models;

namespace BLL.Infrastructure.Profiles
{
    public class GenresProfile : Profile
    {
        public GenresProfile()
        {
            CreateMap<Genre, GenreDTO>().ReverseMap();
        }
    }
}
