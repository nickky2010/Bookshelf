using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EF.Configurations
{
    class BookInformationEntityConfiguration : IEntityTypeConfiguration<BookInformation>
    {
        public void Configure(EntityTypeBuilder<BookInformation> builder)
        {
            builder.HasData(new BookInformation[]
            {
                new BookInformation { Id = 1, Width = 130f, Height = 205f, Weight = 200f, Pages = 352, BookId = 1 },
                new BookInformation { Id = 2, Width = null, Height = null, Weight = null, Pages = 220, BookId = 2 },
                new BookInformation { Id = 3, Width = 130f, Height = 205f, Weight = 520f, Pages = 576, BookId = 3 },
                new BookInformation { Id = 4, Width = 130f, Height = 205f, Weight = 200f, Pages = 352, BookId = 4 }
            });
        }
    }
}
