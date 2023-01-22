using StudentEnrollment.API.DTOs.Course;

namespace StudentEnrollment.API.DTOs.Student
{
    public class StudentDetailsDTO : CreateStudentDTO
    {
        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
    }
}
