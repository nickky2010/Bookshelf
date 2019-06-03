using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DAL.EF.Configurations
{
    class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasOne(b => b.BookInformation).WithOne(b => b.Book).HasForeignKey<BookInformation>(bi => bi.BookId).OnDelete(DeleteBehavior.Restrict);
            builder.HasData(new Book[]
            {
                new Book
                {
                    Id = 1, Name = "A meter away from each other", Year = 2018, ISBN = "978-5-04-100172-8",
                    Edition = "", DateTimeOfAdded = DateTime.Now.AddMonths(-10), BookGroupId = 1,
                    LanguageId = 2, PublishingHouseId = 6, SeriesId = 1
                },
                new Book
                {
                    Id = 2, Name = "Lethal White", Year = 2018, ISBN = "978-5-389-16029-3",
                    Edition = "", DateTimeOfAdded = DateTime.Now.AddMonths(-9).AddDays(-5), BookGroupId = 2,
                    LanguageId = 2, PublishingHouseId = 6, SeriesId = 2
                },
                new Book
                {
                    Id = 3, Name = "The Outsider", Year = 2018, ISBN = "978-5-17-110170-1",
                    Edition = "", DateTimeOfAdded = DateTime.Now.AddMonths(-4).AddDays(-10), BookGroupId = 3,
                    LanguageId = 2, PublishingHouseId = 7, SeriesId = 3
                },
                new Book
                {
                    Id = 4, Name = "В метре друг от друга", Year = 2019, ISBN = "978-5-04-100172-8",
                    Edition = "", DateTimeOfAdded = DateTime.Now.AddMonths(-1).AddDays(-15), BookGroupId = 1,
                    LanguageId = 1, PublishingHouseId = 1, SeriesId = 1
                }
            });
        }
    }
}
