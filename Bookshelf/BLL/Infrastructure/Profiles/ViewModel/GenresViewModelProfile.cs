using AutoMapper;
using BLL.DTO.ViewModel;
using DAL.Models;

namespace BLL.Infrastructure.Profiles
{
    public class GenresViewModelProfile : Profile
    {
        public GenresViewModelProfile()
        {
            CreateMap<Genre, GenreViewModel>().ReverseMap();
        }
    }
}
