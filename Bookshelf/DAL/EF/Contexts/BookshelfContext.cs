using DAL.EF.Configurations;
using DAL.EF.Configurations.Identity;
using DAL.Models;
using DAL.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.Contexts
{
    public class BookshelfContext : DbContext
    {
        readonly string _connectionString;
        public BookshelfContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GenreEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PublishingHouseEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SeriesEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TagEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookGroupEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookInformationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookAuthorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookGenreEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookTagEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<BookGroup> BookGroups { get; set; }
        public DbSet<BookTag> BookTags { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookInformation> Information { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
