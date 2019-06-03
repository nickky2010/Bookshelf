using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EF.Configurations
{
    class BookGroupEntityConfiguration : IEntityTypeConfiguration<BookGroup>
    {
        public void Configure(EntityTypeBuilder<BookGroup> builder)
        {
            builder.HasMany(b => b.Books).WithOne(bg => bg.BookGroup).HasForeignKey(b => b.BookGroupId).OnDelete(DeleteBehavior.Restrict);
            builder.HasData(new BookGroup[]
            {
                new BookGroup { Id = 1 },
                new BookGroup { Id = 2 },
                new BookGroup { Id = 3 }
            });
        }
    }
}
