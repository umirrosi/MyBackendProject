using MyBackendProject.DTO;
using MyBackendProject.Models;

namespace MyBackendProject.DAL
{
    public interface IStudent
    {
        public IEnumerable<Student> GetAll();
        public Student GetById(int ID);
        public IEnumerable<Student> GetByLastName(string lastname);
        public IEnumerable<Student> GetByfirstMidName(string firstmidname);
        public Student Insert(Student student);
        public Student Update(Student student);
        public void Delete(int id);
        public IEnumerable<Student> GetStudentByCourseID(int CourseID);

        //Paging
        Task<IEnumerable<Student>> Pagging(int skip, int take);

    }
}
