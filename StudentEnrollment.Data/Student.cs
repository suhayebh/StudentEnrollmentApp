namespace StudentEnrollment.Data
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth{ get; set; }
        public string IdNumber { get; set; }
        public string Pitcure { get; set; }
    }



}