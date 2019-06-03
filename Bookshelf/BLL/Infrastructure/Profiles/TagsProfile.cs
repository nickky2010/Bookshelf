using AutoMapper;
using BLL.DTO;
using DAL.Models;

namespace BLL.Infrastructure.Profiles
{
    public class TagsProfile : Profile
    {
        public TagsProfile()
        {
            CreateMap<Tag, TagDTO>().ReverseMap();
        }
    }
}
