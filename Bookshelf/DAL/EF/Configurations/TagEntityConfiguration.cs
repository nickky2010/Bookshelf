using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EF.Configurations
{
    class TagEntityConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasData(new Tag[]
                {
                    new Tag { Id = 1, Name = "Novel" },
                    new Tag { Id = 2, Name = "Prose" },
                    new Tag { Id = 3, Name = "Poetry" },
                    new Tag { Id = 4, Name = "Fantasy" },
                    new Tag { Id = 5, Name = "Story" },
                    new Tag { Id = 6, Name = "Detective" },
                    new Tag { Id = 7, Name = "Religion" },
                    new Tag { Id = 8, Name = "Humor" },
                    new Tag { Id = 9, Name = "Science" },
                    new Tag { Id = 10, Name = "Education" },
                    new Tag { Id = 11, Name = "Horrors" }
                });
        }
    }
}
