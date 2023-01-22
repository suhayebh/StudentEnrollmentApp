using AutoMapper;
using StudentEnrollment.API.DTOs.Course;
using StudentEnrollment.API.DTOs.Enrollment;
using StudentEnrollment.API.DTOs.Student;
using StudentEnrollment.Data.Models;

namespace StudentEnrollment.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        { 
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Course, CreateCourseDTO>().ReverseMap();

            CreateMap<Course, CourseDetailsDTO>()
                .ForMember(q => q.Students, x => x.MapFrom(course => course.Enrollments.Select(stu => stu.Student)));

            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Student, CreateStudentDTO>().ReverseMap();
            CreateMap<Student, StudentDetailsDTO>()
                .ForMember(q => q.Courses, x => x.MapFrom(student => student.Enrollments.Select(course => course.Course)));

            CreateMap<Enrollment, EnrollmentDTO>().ReverseMap();
            CreateMap<Enrollment, CreateEnrollmentDTO>().ReverseMap();
        }   
    }
}
