using DAL.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EF.Configurations.Identity
{
    class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role[]
            {
                new Role { Id = 1, Name = "admin" },
                new Role { Id = 2, Name = "user" }
            });
        }
    }
}
