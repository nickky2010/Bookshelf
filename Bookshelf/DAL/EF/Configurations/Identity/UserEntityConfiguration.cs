using DAL.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EF.Configurations.Identity
{
    class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User[]
            {
                new User { Id = 1, Login = "mankonickky@gmail.com", Password = "123456", RoleId = 1 }
            });
        }
    }
}
