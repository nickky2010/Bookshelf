using AutoMapper;
using BLL.DTO.Report;
using DAL.Models;

namespace BLL.Infrastructure.Profiles.Report
{
    public class PublishingHousesProfile : Profile
    {
        public PublishingHousesProfile()
        {
            CreateMap<PublishingHouse, PublishingHouseDTO>().ReverseMap();
        }
    }
}

