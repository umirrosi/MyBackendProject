using MyBackendProject.Models;

namespace MyBackendProject.DAL
{
    public interface IEnrollment
    {
        public IEnumerable<Enrollment> GetAll();
        public Enrollment GetById(int EnrollmentID);
        public Enrollment Insert(Enrollment enrollment);
        public Enrollment Update(Enrollment Enrollment);
        public void Delete(int EnrollmentID);
        public Enrollment AddNewStudenttoCourse(Enrollment enrollment);

        //Query/Store Procedure
        public IEnumerable<Enrollment> GetAllWithQuery();
        public void DeleteEnrollmentForCourse(int CourseID);
        public void DeleteEnrollmentForStudent(int StudentID);
        //Paging
        Task<IEnumerable<Enrollment>> Pagging(int skip, int take);
    }
}
