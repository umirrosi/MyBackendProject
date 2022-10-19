﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBackendProject.DTO;

using MyBackendProject.Models;

namespace MyBackendProject.DAL
{
    public class StudentEF : IStudent
    {
        private AppDbContext _dbcontext;
        private Enrollment enrollment;

        public StudentEF(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void Delete(int id)
        {
            var deleteStudent = GetById(id);
            if (deleteStudent == null)
                throw new Exception($"Data student dengan id {id} tidak ditemukan");
            try
            {
                _dbcontext.Remove(deleteStudent);
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Student> GetAll()
        {
            var results = _dbcontext.students.OrderBy(s => s.LastName).ToList();
            return results;
        }

        public Student GetById(int ID)
        {
            try
            {
                var result = _dbcontext.students.FirstOrDefault(s => s.ID == ID);
                /*var result = (from s in _dbcontext.students
                              where s.ID==id
                              select s).FirstOrDefault():*/
                return result;
            }
            catch 
            {
                throw new Exception($"Data Student tidak ditemukan");
            }
        }

        public IEnumerable<Student> GetByLastName(string lastname)
        {
            var results = _dbcontext.students.
                Where(s => s.LastName.Contains(lastname)).OrderBy(s => s.LastName);
            return results;
        }

        public IEnumerable<Student> GetByfirstMidName(string firstmidname)
         {
            var results = _dbcontext.students.
                Where(s => s.FirstMidName.Contains(firstmidname)).OrderBy(s => s.FirstMidName);
            return results;
        }

    public Student Insert(Student student)
        {
            try
            {
                _dbcontext.students.Add(student);
                _dbcontext.SaveChanges(); 
                return student; 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Student Update(Student student)
        {
            try
            {
                var studentUpdate = GetById(student.ID);
            if (studentUpdate == null)
                {
                    throw new Exception($"Data student id {student.ID} tidak ditemukan");
                }
                
                studentUpdate.LastName = student.LastName;
                studentUpdate.FirstMidName = student.FirstMidName;
                _dbcontext.SaveChanges();

                return student;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Student> GetStudentByCourseID(int CourseID)
        {
            var student = _dbcontext.students
                .FromSqlInterpolated($"exec dbo.GetStudentByCourseID {CourseID}").ToList();
            return student;
        }

        public async Task<IEnumerable<Student>> Pagging(int skip, int take)
        {
            var results = await _dbcontext.students
               .Skip(skip).Take(take).ToArrayAsync();
            return results;
        }

    }
}
