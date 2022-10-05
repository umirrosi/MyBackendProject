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

        public void Delete(int EnrollmentID)
        {
            var deleteEnrollment = GetById(EnrollmentID);
            if (deleteEnrollment == null)
                throw new Exception($"Data Enrollment dengan id {EnrollmentID} tidak ditemukan");
            try
            {
                _dbcontext.Remove(deleteEnrollment);
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //STUDENT WITH COURSE (POST)
        public void Enrollment(int StudentID, int CourseID) 
        {
            try
            {    
                var course = _dbcontext.courses.FirstOrDefault(c => c.CourseID == CourseID);
                var student = _dbcontext.students.FirstOrDefault(s => s.ID == StudentID);

                if (student != null && course != null)
                    //course.students.Add(student);
                    //course.Enrollments.Add(enrollment);
                    //_dbcontext.Add(deleteEnrollment);
                    _dbcontext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Enrollment> GetAll()
        {
            var results = _dbcontext.Enrollment.OrderBy(e => e.EnrollmentID).ToList();
            return results;
        }

        public Enrollment GetByCourseId(int CourseID)
        {
            try
            {
                var result = _dbcontext.Enrollment.FirstOrDefault(e => e.CourseID == CourseID);
                return result;
            }
            catch
            {
                throw new Exception($"Data Student tidak ditemukan");
            }
        }

        public IEnumerable<Enrollment> GetByGrade(string grade)
        {
            throw new NotImplementedException();
        }

        public Enrollment GetById(int EnrollmentID)
        {
            try
            {
                var result = _dbcontext.Enrollment.FirstOrDefault(e => e.EnrollmentID == EnrollmentID);
                return result;
            }
            catch
            {
                throw new Exception($"Data Student tidak ditemukan");
            }
        }

        public Enrollment GetByStudentId(int StudentID)
        {
            try
            {
                var result = _dbcontext.Enrollment.FirstOrDefault(e => e.StudentID == StudentID);
                return result;
            }
            catch
            {
                throw new Exception($"Data Student tidak ditemukan");
            }
        }

        public Enrollment Insert(Enrollment enrollment)
        {
            try
            {
                var course = _dbcontext.courses.FirstOrDefault(c => c.CourseID == enrollment.CourseID);
                var student = _dbcontext.students.FirstOrDefault(s => s.ID == enrollment.StudentID);

                if (student != null && course != null)
                {
                    _dbcontext.Enrollment.Add(enrollment);
                    _dbcontext.SaveChanges();
                }
                    
                return enrollment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Enrollment Update(Enrollment Enrollment)
        {
            try
            {
                var enrollmentUpdate = GetById(enrollment.EnrollmentID);
                if (enrollmentUpdate == null)
                {
                    throw new Exception($"Data Enrollment {enrollment.EnrollmentID} tidak ditemukan");
                }

                enrollmentUpdate.StudentID = enrollment.StudentID;
                enrollmentUpdate.CourseID = enrollment.CourseID;
                enrollmentUpdate.Grade = enrollment.Grade;
                _dbcontext.SaveChanges();

                return enrollment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
