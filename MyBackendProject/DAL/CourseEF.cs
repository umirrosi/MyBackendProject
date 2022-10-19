using Microsoft.EntityFrameworkCore;

using MyBackendProject.Models;
using static System.Net.Mime.MediaTypeNames;

namespace MyBackendProject.DAL
{
    public class CourseEF : ICourse
    {
        private AppDbContext _dbcontext;

        public CourseEF(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void Delete(int courseId)
        { 
            var deleteCourse = GetByCourseId(courseId);
            if (deleteCourse == null)
                throw new Exception($"Data Course dengan id {courseId} tidak ditemukan");
            try 
            {
                _dbcontext.courses.Remove((Course)deleteCourse);
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Course> GetAll()
        {
            var results = _dbcontext.courses.OrderBy(c => c.Title).ToList();
            return results;
        }

        public Course GetByCourseId(int courseId)
        {
            var result = _dbcontext.courses.FirstOrDefault(c => c.CourseID == courseId);
            return result;

            //var result = _dbcontext.courses.FirstOrDefault(c => c.CourseID == courseId);
            //if (result == null)
            //    throw new Exception($"Data {courseId} tidak ditemukan");
            //return result;

        }


        public IEnumerable<Course> GetByTitle(string title)
        {
            var quotes = _dbcontext.courses.Where(c => c.Title.Contains(title));
            return quotes;
        }

        public Course Insert(Course course)
        {
            try
            {
                _dbcontext.courses.Add(course);
                _dbcontext.SaveChanges();
                return course;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Course Update(Course course)
        {
            try
            {
                var courseUpdate = GetByCourseId(course.CourseID);
                if (courseUpdate == null)
                {
                    throw new Exception($"Data CourseId {course.CourseID} tidak ditemukan");
                }

                courseUpdate.Title = course.Title;
                courseUpdate.Credits = course.Credits;
                _dbcontext.SaveChanges();

                return course;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Course> GetCourseByStudentID(int StudentID)
        {
            var course = _dbcontext.courses
                .FromSqlInterpolated($"exec dbo.GetCourseByStudentID {StudentID}").ToList();
            return course;
        }
    }
}
