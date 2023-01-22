using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentEnrollment.Data.Models;

namespace StudentEnrollment.Data.Configuration
{
    internal class SchoolUserConfiguration : IEntityTypeConfiguration<SchoolUser>
    {
        public void Configure(EntityTypeBuilder<SchoolUser> builder)
        {
            var hasher = new PasswordHasher<SchoolUser>();
            builder.HasData(
                new SchoolUser
                {
                    Id= "9db11d1c-8493-4279-9dd7-0b346a3f7f77",
                    Email = "admin@school.ae",
                    NormalizedEmail = "ADMIN@SCHOOL.AE",
                    NormalizedUserName = "ADMIN@SCHOOL.AE",
                    UserName= "admin@school.ae",
                    FirstName = "Sean",
                    LastName = "ScPickkle",
                    PasswordHash = hasher.HashPassword(null, "Test@1234")
                },
                new SchoolUser
                {
                    Id = "21bd9497-94f6-484b-b3a9-f59d5c9e1efb",
                    Email = "principle@school.ae",
                    NormalizedEmail = "PRINCIPLE@SCHOOL.AE",
                    NormalizedUserName = "PRINCIPLE@SCHOOL.AE",
                    UserName = "principle@school.ae",
                    FirstName = "Suha",
                    LastName = "ScPickkles",
                    PasswordHash = hasher.HashPassword(null, "Test@1234")
                }
            );
        }
    }
}
