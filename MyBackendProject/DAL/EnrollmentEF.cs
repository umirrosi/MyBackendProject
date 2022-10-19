using Microsoft.EntityFrameworkCore;
using MyBackendProject.DTO;
using MyBackendProject.Models;
using System.Collections;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

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

        public IEnumerable<Enrollment> GetAll()
        {
            var results = _dbcontext.Enrollment.OrderBy(e => e.EnrollmentID).ToList();
            return results;
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


        //STUDENT WITH COURSE (POST)
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

        //NEW STUDENT WITH COURSE (POST)
        public Enrollment AddNewStudenttoCourse(Enrollment enrollment)
        {
            try
            {
                var course = _dbcontext.courses.FirstOrDefault(c => c.CourseID == enrollment.CourseID);
                var student = _dbcontext.students.FirstOrDefault(s => s.ID == enrollment.StudentID);
                _dbcontext.students.Add(student);

                if (course != null)
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

        public Enrollment Update(Enrollment enrollment)
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

        public IEnumerable<Enrollment> GetAllWithQuery()
        {
            var enrollment = _dbcontext.Enrollment
                .FromSqlInterpolated($"exec dbo.GetAllWithQuery").ToList();
            return enrollment;
        }

        public void DeleteEnrollmentForCourse(int CourseID)
        {
            try
            {
                _dbcontext.Database.ExecuteSqlInterpolated($"exec dbo.DeleteEnrollmentForCourse {CourseID}");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void DeleteEnrollmentForStudent(int StudentID)
        {
            try
            {
                _dbcontext.Database.ExecuteSqlInterpolated($"exec dbo.DeleteEnrollmentForStudent {StudentID}");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Enrollment>> Pagging(int skip, int take)
        {
            var results = await _dbcontext.Enrollment.Include(s => s.Course).Include(s => s.Student)
               .Skip(skip).Take(take).ToArrayAsync();
            return results;
        }
    }
}
