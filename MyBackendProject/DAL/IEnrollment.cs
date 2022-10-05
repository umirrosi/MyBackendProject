using MyBackendProject.Models;

namespace MyBackendProject.DAL
{
    public interface IEnrollment
    {
        public IEnumerable<Enrollment> GetAll();
        public Enrollment GetById(int EnrollmentID);
        public Enrollment GetByStudentId(int StudentID);
        public IEnumerable<Enrollment> GetByGrade(string grade);
        public Enrollment GetByCourseId(int CourseID);
        public Enrollment Insert(Enrollment enrollment);
        public Enrollment Update(Enrollment Enrollment);
        public void Delete(int id);

        //mendaftarkan student yang sudah ada ke course yang sudah ada
        public void Enrollment(int StudentID, int CourseID);
    }
}
