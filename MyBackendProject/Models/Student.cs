namespace MyBackendProject.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();


        //public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
