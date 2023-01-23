namespace StudentEnrollment.API.DTOs.Student
{
    public class CreateStudentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string IdNumber { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string ProfilePictureUrl { get; set;}
    }
}
