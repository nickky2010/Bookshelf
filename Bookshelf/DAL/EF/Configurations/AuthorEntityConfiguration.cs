using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EF.Configurations
{
    class AuthorEntityConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(p => p.RowVersion).IsRowVersion();
            builder.HasData(new Author[]
            {
                    new Author { Id = 1, FirstName = "Mickey", LastName = "Dotry" },
                    new Author { Id = 2, FirstName = "Tobias", LastName = "Iakonis" },
                    new Author { Id = 3, FirstName = "Rachel", LastName = "Lippincott" },
                    new Author { Id = 4, FirstName = "Joanne", LastName = "Rowling" },
                    new Author { Id = 5, FirstName = "Stephen", LastName = "King" },
                    new Author { Id = 6, FirstName = "Fedor", LastName = "Dostoevsky" },
                    new Author { Id = 7, FirstName = "Nickolai", LastName = "Nosov" }
            });
        }
    }
}
