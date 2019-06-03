using DAL.Models;
using DAL.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork<C>: IDisposable 
        where C : DbContext
    {
        IRepository<Author> Authors { get; }
        IRepository<Book> Books { get; }
        IRepository<Genre> Genres { get; }
        IRepository<BookInformation> BookInformation { get; }
        IRepository<Language> Languages { get; }
        IRepository<PublishingHouse> PublishingHouses { get; }
        IRepository<Series> Series { get; }
        IRepository<BookAuthor> BookAuthors { get; }
        IRepository<BookGenre> BookGenres { get; }
        IRepository<BookGroup> BookGroups { get; }
        IRepository<BookTag> BookTags { get; }
        IRepository<Tag> Tags { get; }
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        Task<int> SaveChangesAsync();
    }
}
