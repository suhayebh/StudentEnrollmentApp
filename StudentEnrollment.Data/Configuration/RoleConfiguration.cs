using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentEnrollment.Data.Configuration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id= "4b43c232-78c5-4640-8bec-c493890ff874",
                    Name = "Administrator",
                    NormalizedName= "ADMINISTRATOR",
                },
                new IdentityRole
                {
                    Id= "8bcedbe7-efb9-4dbe-abdb-5c72c13eecf4",
                    Name = "User",
                    NormalizedName = "USER",
                }
            );
        }
    }
}
