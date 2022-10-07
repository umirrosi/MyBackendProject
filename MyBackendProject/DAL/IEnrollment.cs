using MyBackendProject.Models;

namespace MyBackendProject.DAL
{
    public interface IEnrollment
    {
        public IEnumerable<Enrollment> GetAll();
        public Enrollment GetById(int EnrollmentID);
        //public Enrollment GetByStudentId(int StudentID);
        //public IEnumerable<Enrollment> GetByGrade(string grade);
        //public Enrollment GetByCourseId(int CourseID);
        public Enrollment Insert(Enrollment enrollment);
        public Enrollment Update(Enrollment Enrollment);
        public void Delete(int EnrollmentID);

        //mendaftarkan student yang sudah ada ke course yang sudah ada
        //public void Enrollment(int StudentID, int CourseID);
        public Enrollment AddNewStudenttoCourse(Enrollment enrollment);
        //Query
        public IEnumerable<Enrollment> GetAllWithQuery();
        public void DeleteEnrollmentForCourse(int CourseID);
        public void DeleteEnrollmentForStudent(int StudentID);
    }
}
