using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EF.Configurations
{
    class LanguageEntityConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasMany(b => b.Books).WithOne(ba => ba.Language).HasForeignKey(b => b.LanguageId).OnDelete(DeleteBehavior.Restrict);
            builder.HasData(new Language[]
                {
                    new Language{ Id = 1, Name = "Russian" },
                    new Language{ Id = 2, Name = "English" },
                    new Language{ Id = 3, Name = "French" },
                    new Language{ Id = 4, Name = "Deutsch" },
                    new Language{ Id = 5, Name = "Japanese" },
                    new Language{ Id = 6, Name = "Chinese" },
                    new Language{ Id = 7, Name = "Spanish" }
                });
        }
    }
}
