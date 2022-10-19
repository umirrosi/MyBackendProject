using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBackendProject.DAL;
using MyBackendProject.DTO;
using MyBackendProject.Models;

namespace MyBackendProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;
        private readonly IMapper _mapper;
        private AppDbContext _dbcontext;

        public StudentController(IStudent student, IMapper mapper, AppDbContext dbcontext)
        {
            _student = student;
            _mapper = mapper;
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public IEnumerable<StudentGetDTO> Get()
        {
            var results = _student.GetAll();
            var lstStudentGetDto = _mapper.Map<IEnumerable<StudentGetDTO>>(results);
            return lstStudentGetDto;

            //List<StudentGetDTO> lstStudentGetDto = new List<StudentGetDTO>();
            //var results = _student.GetAll();
            //foreach (var s in results)
            //{
            //    lstStudentGetDto.Add(new StudentGetDTO
            //    {
            //        Id = s.ID,
            //        LastName = s.LastName,
            //        FirstMidName = s.FirstMidName 
            //    });
            //}
            //return lstStudentGetDto;

        }

        [HttpGet("{id}")]
        public StudentGetDTO Get(int id)
        {
            //try
            //{
                var result = _student.GetById(id);
                var studentGetDto = _mapper.Map<StudentGetDTO>(result);
                return studentGetDto;
            //}

            //    var result = _student.GetById(id);
            //    var studentGetDto = new StudentGetDTO();
            //    string nama = " ";
            //    if (result != null)
            //    {
            //        studentGetDto = new StudentGetDTO
            //        {
            //            Id = result.ID,
            //            LastName = result.LastName,
            //            FirstMidName = result.FirstMidName
            //        };
            //        nama = result.FirstMidName +  result.LastName;
            //    }
            //    else
            //    {
            //        nama = "ID " + id +  " tidak ditemukan"; 
            //    }
            //    return nama;
            //}
            //catch
            //{
            //    throw new Exception($"Data student tidak ditemukan");
            //}
        }


        [HttpGet("ByLastName")]
        public IEnumerable<StudentGetDTO> GetByLastName(string lastname)
        {
            var results = _student.GetByLastName(lastname);
            var listStudentGetDto = _mapper.Map<IEnumerable<StudentGetDTO>>(results);
            return listStudentGetDto;

            //List<StudentGetDTO> listStudentGetDto = new List<StudentGetDTO>();
            //var results = _student.GetByLastName(lastname);
            //foreach (var r in results)
            //{
            //    listStudentGetDto.Add(new StudentGetDTO
            //    {
            //        Id = r.ID,
            //        LastName = r.LastName,
            //        FirstMidName = r.FirstMidName
            //    });
            //}
            //return listStudentGetDto;
        }

        [HttpGet("ByFirstMidName")]
        public IEnumerable<StudentGetDTO> GetByfirstMidName(string firstmidname)
        {
            var results = _student.GetByfirstMidName(firstmidname);
            var listStudentGetDto = _mapper.Map<IEnumerable<StudentGetDTO>>(results);
            return listStudentGetDto;

            //List<StudentGetDTO> listStudentGetDto = new List<StudentGetDTO>();
            //var results = _student.GetByfirstMidName(firstmidname);
            //foreach (var r in results)
            //{
            //    listStudentGetDto.Add(new StudentGetDTO
            //    {
            //        Id = r.ID,
            //        LastName = r.LastName,
            //        FirstMidName = r.FirstMidName
            //    });
            //}
            //return listStudentGetDto;
        }

        [HttpPost]
        public IActionResult Post(StudentAddDTO studentDto)
        {
            try
            {
                var student = _mapper.Map<Student>(studentDto);
                var newStudent = _student.Insert(student);
                var studentGetDto = _mapper.Map<StudentGetDTO>(newStudent);

                //var student = new Student 
                //{
                //    LastName = studentDto.LastName,
                //    FirstMidName = studentDto.FirstMidName
                //};

                //var newStudent = _student.Insert(student);

                //var studentGetDto = new StudentGetDTO
                //{
                //    Id = newStudent.ID,
                //    LastName = newStudent.LastName,
                //    FirstMidName = newStudent.FirstMidName
                //};
                return CreatedAtAction("Get", new { id = studentGetDto.Id }, studentGetDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(StudentGetDTO studentDto)
        {
            try
            {
                var student = _mapper.Map<Student>(studentDto);
                var editStudent = _student.Update(student);
                var studentGetDto = _mapper.Map<StudentGetDTO>(editStudent);
                return Ok(studentGetDto);

                //var student = new Student
                //{
                //    ID= id,
                //    LastName = studentDto.LastName,
                //    FirstMidName = studentDto.FirstMidName
                //};

                //var editStudent = _student.Update(student);

                //StudentGetDTO studentGetDto = new StudentGetDTO
                //{
                //    Id = student.ID,
                //    LastName = studentDto.LastName,
                //    FirstMidName = studentDto.FirstMidName
                //};

                //return Ok(studentGetDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _student.Delete(id);
                return Ok($"Delete id {id} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("StudentByCourseID")]
        public IEnumerable<StudentGetDTO> GetStudentByCourseID(int CourseID)
        {
            var student = _student.GetStudentByCourseID(CourseID);
            var studentGetDTO = _mapper.Map<IEnumerable<StudentGetDTO>>(student);
            return studentGetDTO;
        }

        [HttpGet("Pagging/{skip}/{take}")]
        public async Task<IEnumerable<StudentGetDTO>> Pagging(int skip, int take)
        {

            var results = await _student.Pagging(skip, take);
            var DTO = _mapper.Map<IEnumerable<StudentGetDTO>>(results);

            return DTO;
        }

    }
}

