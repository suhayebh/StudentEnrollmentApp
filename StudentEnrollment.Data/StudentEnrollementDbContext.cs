using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using StudentEnrollment.Data.Configuration;
using StudentEnrollment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Data
{
    public class StudentEnrollementDbContext : IdentityDbContext
    {
        public StudentEnrollementDbContext(DbContextOptions<StudentEnrollementDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments{ get; set; }
    }

    public class StudentEnrollmentDbContextFactory : IDesignTimeDbContextFactory<StudentEnrollementDbContext>
    {
        public StudentEnrollementDbContext CreateDbContext(string[] args)
        {
            //Get environement
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //Build config
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            //Get connection string
            var optionBuilder = new DbContextOptionsBuilder<StudentEnrollementDbContext>();
            var connectionString = config.GetConnectionString("StudentDbConnection");
            optionBuilder.UseSqlServer(connectionString); 
            return new StudentEnrollementDbContext(optionBuilder.Options);

        }
    }
}
