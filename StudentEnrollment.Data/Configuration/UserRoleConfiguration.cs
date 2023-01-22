using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentEnrollment.Data.Configuration
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "4b43c232-78c5-4640-8bec-c493890ff874",
                    UserId = "9db11d1c-8493-4279-9dd7-0b346a3f7f77",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "8bcedbe7-efb9-4dbe-abdb-5c72c13eecf4",
                    UserId = "21bd9497-94f6-484b-b3a9-f59d5c9e1efb",
                }
            );
        }
    }
}
