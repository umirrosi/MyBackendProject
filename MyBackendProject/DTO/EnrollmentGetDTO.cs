using MyBackendProject.Models;

namespace MyBackendProject.DTO
{
    public class EnrollmentGetDTO
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public int Grade { get; set; }
    }
}
