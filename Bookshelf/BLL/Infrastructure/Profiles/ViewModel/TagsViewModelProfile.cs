using AutoMapper;
using BLL.DTO.ViewModel;
using DAL.Models;

namespace BLL.Infrastructure.Profiles
{
    public class TagsViewModelProfile : Profile
    {
        public TagsViewModelProfile()
        {
            CreateMap<Tag, TagViewModel>().ReverseMap();
        }
    }
}
