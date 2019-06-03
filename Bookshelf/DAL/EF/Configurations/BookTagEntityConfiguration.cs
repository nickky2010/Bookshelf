using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EF.Configurations
{
    class BookTagEntityConfiguration : IEntityTypeConfiguration<BookTag>
    {
        public void Configure(EntityTypeBuilder<BookTag> builder)
        {
            builder.HasKey(bt => new { bt.BookId, bt.TagId });
            builder.HasOne(b => b.Book).WithMany(bt => bt.BookTags).HasForeignKey(b => b.BookId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Tag).WithMany(bt => bt.BookTags).HasForeignKey(t => t.TagId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(b => b.BookId).ValueGeneratedNever();
            builder.Property(t => t.TagId).ValueGeneratedNever();

            builder.HasData(new BookTag[]
            {
                new BookTag { BookId = 1, TagId = 1 },
                new BookTag { BookId = 2, TagId = 1 },
                new BookTag { BookId = 3, TagId = 11 },
                new BookTag { BookId = 3, TagId = 1 },
                new BookTag { BookId = 4, TagId = 1 }
            });
        }
    }
}
