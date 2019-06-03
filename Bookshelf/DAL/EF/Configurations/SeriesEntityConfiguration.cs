using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EF.Configurations
{
    class SeriesEntityConfiguration : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.HasMany(b => b.Books).WithOne(s => s.Series).HasForeignKey(s => s.SeriesId).OnDelete(DeleteBehavior.Restrict);
            builder.HasData(new Series[]
                {
                    new Series { Id = 1, Name = "Young Adult" },
                    new Series { Id = 2, Name = "Foreign literature" },
                    new Series { Id = 3, Name = "Dark tower" }
                });
        }
    }
}
