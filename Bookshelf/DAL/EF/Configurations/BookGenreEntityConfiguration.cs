using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EF.Configurations
{
    class BookGenreEntityConfiguration : IEntityTypeConfiguration<BookGenre>
    {
        public void Configure(EntityTypeBuilder<BookGenre> builder)
        {
            builder.HasKey(bg => new { bg.BookId, bg.GenreId });
            builder.HasOne(b => b.Book).WithMany(bg => bg.BookGenres).HasForeignKey(b => b.BookId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(g => g.Genre).WithMany(bg => bg.BookGenres).HasForeignKey(g => g.GenreId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(b => b.BookId).ValueGeneratedNever();
            builder.Property(g => g.GenreId).ValueGeneratedNever();
            builder.HasData(new BookGenre[]
            {
                new BookGenre { BookId = 1, GenreId = 1 },
                new BookGenre { BookId = 2, GenreId = 1 },
                new BookGenre { BookId = 3, GenreId = 11 },
                new BookGenre { BookId = 3, GenreId = 1 },
                new BookGenre { BookId = 4, GenreId = 1 }
            });
        }
    }
}
