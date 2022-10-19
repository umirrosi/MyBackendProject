using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBackendProject.DAL;
using MyBackendProject.DTO;
using MyBackendProject.Models;
using System.Collections;

namespace MyBackendProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private IStudent _student;
        private IEnrollment _enrollment;
        private IMapper _mapper;
        public EnrollmentController(IEnrollment enrollment, IMapper mapper, IStudent student)
        {
            _enrollment = enrollment;
            _mapper = mapper;
            _student = student;
        }


        private AppDbContext _dbcontext;

        [HttpGet]
        public IEnumerable<EnrollmentGetDTO> Get()
        {
            var results = _enrollment.GetAll();
            var lstenrollments = _mapper.Map<IEnumerable<EnrollmentGetDTO>>(results);
            return lstenrollments;
        }

        [HttpGet("ByEnrollmentID")]
        public EnrollmentGetFirstDTO Get(int EnrollmentID)
        {
            var result = _enrollment.GetById(EnrollmentID);
            var enrollmentGetDto = _mapper.Map<EnrollmentGetFirstDTO>(result);
            return enrollmentGetDto;
        }


        [HttpPost("StudentWithCourse")]
        public IActionResult Enrollment(EnrollmentAddDTO enrollmentDto)
        {
            try
            {
                var enrollment = new Enrollment
                {
                    CourseID = enrollmentDto.CourseID,
                    StudentID = enrollmentDto.StudentID,          
                };

                var newEnrollment = _enrollment.Insert(enrollment);

                var enrollmentGetDto = new EnrollmentGetDTO
                {
                    CourseID = newEnrollment.CourseID,
                    StudentID = newEnrollment.StudentID,
                };
                return Ok($"StudentID {enrollmentGetDto.StudentID} berhasil dittambahkan ke Course {enrollmentGetDto.CourseID}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("NewStudentWithCourse")]
        public IActionResult AddNewStudenttoCourse(string firstname, string lastname,EnrollmentAddDTO enrollmentDto)
        {
            try
            {
                var enrollment = new Enrollment
                {
                    CourseID = enrollmentDto.CourseID,
                    StudentID = enrollmentDto.StudentID,               
                };

                var student = new Student
                {
                    FirstMidName = firstname,
                    LastName = lastname,              
                };

                var newStudent = _student.Insert(student); //insert ke database student

                enrollment.StudentID = newStudent.ID;

                var newEnrollment = _enrollment.Insert(enrollment);

                var enrollmentGetDto = new EnrollmentGetDTO
                {
                    EnrollmentID = newEnrollment.EnrollmentID,
                    CourseID = newEnrollment.CourseID,
                    StudentID = newEnrollment.StudentID,
                };
                return Ok($"New StudentID {enrollmentGetDto.StudentID} berhasil dittambahkan ke Course {enrollmentGetDto.CourseID}");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public IActionResult Put(EnrollmentAddDTO enrollmentDto)
        {
            try
            {
                var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
                var editEnrollment = _enrollment.Update(enrollment);
                var enrollmentGetDto = _mapper.Map<EnrollmentGetDTO>(editEnrollment);
                return Ok(enrollmentGetDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("ByEnrollmentID")]
        public IActionResult Delete(int EnrollmentID)
        {
            try
            {
                _enrollment.Delete(EnrollmentID);
                return Ok($"Delete id {EnrollmentID} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllWithQuery")]
        public IEnumerable<EnrollmentGetDTO> GetAllWithQuery()
        {
            var results = _enrollment.GetAllWithQuery();
            var lstenrollments = _mapper.Map<IEnumerable<EnrollmentGetDTO>>(results);
            return lstenrollments;
        }

        [HttpDelete("AllStudent/{CourseID}")]
        public IActionResult DeleteEnrollmentForCourse(int CourseID)
        {
            try
            {
                _enrollment.DeleteEnrollmentForCourse(CourseID);
                return Ok($"Semua student yang ada dalam CourseID {CourseID} berhasil di Hapus");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("AllCourse/{StudentID}")]
        public IActionResult DeleteEnrollmentForStudent(int StudentID)
        {
            try
            {
                _enrollment.DeleteEnrollmentForStudent(StudentID);
                return Ok($"Semua Course yang diambil oleh StudentID {StudentID} berhasil dihapus");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Pagging/{skip}/{take}")]
        public async Task<IEnumerable<EnrollmentGetDTO>> Pagging(int skip, int take)
        {

            var results = await _enrollment.Pagging(skip, take);
            var enrollmentDTO = _mapper.Map<IEnumerable<EnrollmentGetDTO>>(results);

            return enrollmentDTO;
        }

    }
}
