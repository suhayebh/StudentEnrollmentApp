using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Data.Configuration
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
                new Course
                {
                    Id = 1,
                    Title = "Backend Dev, .NET7 Minimal API",
                    Credits = 8
                },
                new Course
                {
                    Id = 2,
                    Title = "Frontend Dev, Vuejs Complete Guide",
                    Credits = 32
                }
            );
        }
    }
}
