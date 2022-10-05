using Microsoft.EntityFrameworkCore;
using MyBackendProject.DTO;
using MyBackendProject.Models;

namespace MyBackendProject.DAL
{
    public class EnrollmentEF : IEnrollment
    {
        private AppDbContext _dbcontext;
        private Enrollment enrollment;

        public EnrollmentEF(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Enrollment(int StudentID, int CourseID) 
        {
            try
            {
                var course = _dbcontext.courses.FirstOrDefault(c => c.CourseID == CourseID);
                var student = _dbcontext.students.FirstOrDefault(s => s.ID == StudentID);

                if (student != null && course != null)

                    //course.students.Add(student);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
