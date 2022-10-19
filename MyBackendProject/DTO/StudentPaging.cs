using MyBackendProject.Models;

namespace MyBackendProject.DTO
{
    public class StudentPaging
    {
        public List<Student> Student { get; set; } = new List<Student>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
