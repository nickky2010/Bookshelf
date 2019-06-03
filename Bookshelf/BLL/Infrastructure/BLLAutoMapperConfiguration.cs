using AutoMapper;
using BLL.Infrastructure.Profiles;
using BLL.Infrastructure.Profiles.Identity;
using BLL.Infrastructure.Profiles.Report;

namespace BLL.Infrastructure
{
    public class BLLAutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new RolesProfile());
                cfg.AddProfile(new UsersProfile());
                cfg.AddProfile(new AuthorsProfile());
                cfg.AddProfile(new BooksProfile());
                cfg.AddProfile(new GenresProfile());
                cfg.AddProfile(new TagsProfile());
                cfg.AddProfile(new PublishingHousesProfile());
                cfg.AddProfile(new AuthorsViewModelProfile());
                cfg.AddProfile(new BooksViewModelProfile());
                cfg.AddProfile(new GenresViewModelProfile());
                cfg.AddProfile(new TagsViewModelProfile());
                cfg.AddProfile(new UsersViewModelProfile());
                cfg.AddProfile(new RolesViewModelProfile());
            });
        }
    }
}
