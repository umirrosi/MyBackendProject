using MyBackendProject.Models;

namespace MyBackendProject.DAL
{
    public interface IEnrollment
    {
        //mendaftarkan student yang sudah ada ke course yang sudah ada
        public void Enrollment(int StudentID, int CourseID);
    }
}
