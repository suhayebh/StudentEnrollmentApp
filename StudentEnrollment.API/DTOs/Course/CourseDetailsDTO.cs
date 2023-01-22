using StudentEnrollment.API.DTOs.Student;

namespace StudentEnrollment.API.DTOs.Course
{
    public class CourseDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();
    }


}
