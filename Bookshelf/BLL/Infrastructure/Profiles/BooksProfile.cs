using AutoMapper;
using BLL.DTO;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Infrastructure.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForPath(dest => dest.Height, opts => opts.MapFrom(m => m.BookInformation.Height))
                .ForPath(dest => dest.Width, opts => opts.MapFrom(m => m.BookInformation.Width))
                .ForPath(dest => dest.Weight, opts => opts.MapFrom(m => m.BookInformation.Weight))
                .ForPath(dest => dest.Pages, opts => opts.MapFrom(m => m.BookInformation.Pages))
                .ForPath(dest => dest.BookGroup, opts => opts.MapFrom(m => m.BookGroup.Id))
                .ForPath(dest => dest.Language, opts => opts.MapFrom(m => m.Language.Name))
                .ForPath(dest => dest.PublishingHouse, opts => opts.MapFrom(m => m.PublishingHouse.Name))
                .ForPath(dest => dest.Series, opts => opts.MapFrom(m => m.Series.Name))
                .AfterMap((b, bdto) => { bdto.Authors = Mapper.Map<ICollection<AuthorDTO>>(b.BookAuthors.Select(a => a.Author).ToList()); })
                .AfterMap((b, bdto) => { bdto.Genres = Mapper.Map<ICollection<GenreDTO>>(b.BookGenres.Select(a => a.Genre).ToList()); })
                .AfterMap((b, bdto) => { bdto.Tags = Mapper.Map<ICollection<TagDTO>>(b.BookTags.Select(a => a.Tag).ToList()); });
            CreateMap<BookDTO, Book>()
                .ForPath(dest => dest.BookInformation.Height, opts => opts.MapFrom(m => m.Height))
                .ForPath(dest => dest.BookInformation.Width, opts => opts.MapFrom(m => m.Width))
                .ForPath(dest => dest.BookInformation.Weight, opts => opts.MapFrom(m => m.Weight))
                .ForPath(dest => dest.BookInformation.Pages, opts => opts.MapFrom(m => m.Pages))
                .ForPath(dest => dest.BookGroup.Id, opts => opts.MapFrom(m => m.BookGroup))
                .ForPath(dest => dest.Language.Name, opts => opts.MapFrom(m => m.Language))
                .ForPath(dest => dest.PublishingHouse.Name, opts => opts.MapFrom(m => m.PublishingHouse))
                .ForPath(dest => dest.Series.Name, opts => opts.MapFrom(m => m.Series));
        }
    }
}
