using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data.Models;

namespace StudentEnrollment.Data.Repositories
{
    public class EnrollementRepository : GenericRepository<Enrollment>, IEnrollmentRespository
    {
        public EnrollementRepository(StudentEnrollementDbContext db) : base(db)
        {
        }
    }
}
