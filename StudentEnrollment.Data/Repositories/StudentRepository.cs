using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data.Models;
using StudentEnrollment.Data.Repositories;

namespace StudentEnrollment.Data.Contracts
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentEnrollementDbContext db) : base(db)
        {
        }

        public async Task<Student> GetStudentDetails(int studentId)
        {
            return await _db.Students
                .Include(q => q.Enrollments).ThenInclude(q => q.Course)
                .FirstOrDefaultAsync(q => q.Id == studentId);
        }
    }
}
