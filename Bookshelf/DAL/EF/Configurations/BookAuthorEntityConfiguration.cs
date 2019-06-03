using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EF.Configurations
{
    class BookAuthorEntityConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(ba => new { ba.BookId, ba.AuthorId });
            builder.HasOne(b => b.Book).WithMany(ba => ba.BookAuthors).HasForeignKey(b => b.BookId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Author).WithMany(ba => ba.BookAuthors).HasForeignKey(a => a.AuthorId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(b => b.BookId).ValueGeneratedNever();
            builder.Property(a => a.AuthorId).ValueGeneratedNever();
            builder.HasData(new BookAuthor[]
            {
                new BookAuthor { BookId = 1, AuthorId = 1 },
                new BookAuthor { BookId = 1, AuthorId = 2 },
                new BookAuthor { BookId = 1, AuthorId = 3 },
                new BookAuthor { BookId = 2, AuthorId = 4 },
                new BookAuthor { BookId = 3, AuthorId = 5 },
                new BookAuthor { BookId = 4, AuthorId = 1 },
                new BookAuthor { BookId = 4, AuthorId = 2 },
                new BookAuthor { BookId = 4, AuthorId = 3 }
            });
        }
    }
}
