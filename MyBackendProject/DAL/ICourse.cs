using MyBackendProject.Models;

namespace MyBackendProject.DAL
{
    public interface ICourse
    {
        public IEnumerable<Course> GetAll();
        public Course GetByCourseId(int courseId);
        public IEnumerable<Course> GetByTitle(string title);
        public Course Insert(Course course);
        public Course Update(Course course);
        public void Delete(int courseId);

        public IEnumerable<Course> GetCourseByStudentID(int StudentID);
    }
}
