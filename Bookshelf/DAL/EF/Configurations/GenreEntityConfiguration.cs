using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EF.Configurations
{
    class GenreEntityConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(new Genre[]
            {
                new Genre { Id = 1, Name = "Novel" },
                new Genre { Id = 2, Name = "Prose" },
                new Genre { Id = 3, Name = "Poetry" },
                new Genre { Id = 4, Name = "Fantasy" },
                new Genre { Id = 5, Name = "Story" },
                new Genre { Id = 6, Name = "Detective" },
                new Genre { Id = 7, Name = "Religion" },
                new Genre { Id = 8, Name = "Humor" },
                new Genre { Id = 9, Name = "Science" },
                new Genre { Id = 10, Name = "Education" },
                new Genre { Id = 11, Name = "Horrors" }
            });
        }
    }
}
