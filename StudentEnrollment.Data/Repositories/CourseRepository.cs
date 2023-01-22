using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data.Models;
using StudentEnrollment.Data.Repositories;

namespace StudentEnrollment.Data.Contracts
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(StudentEnrollementDbContext db) : base(db)
        {
        }

        public async Task<Course> GetStudentList(int courseId)
        {
            return await _db.Courses.Include(q => q.Enrollments).ThenInclude(q => q.Student).FirstOrDefaultAsync(q => q.Id == courseId);
        }
    }
}
