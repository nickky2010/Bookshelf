using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EF.Configurations
{
    class PublishingHouseEntityConfiguration : IEntityTypeConfiguration<PublishingHouse>
    {
        public void Configure(EntityTypeBuilder<PublishingHouse> builder)
        {
            builder.HasMany(b => b.Books).WithOne(p => p.PublishingHouse).HasForeignKey(p => p.PublishingHouseId).OnDelete(DeleteBehavior.Restrict);
            builder.HasData(new PublishingHouse[]
                {
                    new PublishingHouse{ Id = 1, Name = "Eksmo" },
                    new PublishingHouse{ Id = 2, Name = "Piter" },
                    new PublishingHouse{ Id = 3, Name = "Williams" },
                    new PublishingHouse{ Id = 4, Name = "Knorus" },
                    new PublishingHouse{ Id = 5, Name = "Aversev" },
                    new PublishingHouse{ Id = 6, Name = "Penguin Random House" },
                    new PublishingHouse{ Id = 7, Name = "ACT" }
                });
        }
    }
}
