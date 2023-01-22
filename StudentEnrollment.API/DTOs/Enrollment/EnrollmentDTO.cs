using StudentEnrollment.API.DTOs.Course;
using StudentEnrollment.API.DTOs.Student;

namespace StudentEnrollment.API.DTOs.Enrollment
{
    public class EnrollmentDTO
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public virtual CourseDTO Course { get; set; }
        public virtual StudentDTO Student { get; set; }
    }
}
