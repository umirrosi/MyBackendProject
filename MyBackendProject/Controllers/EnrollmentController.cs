using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBackendProject.DAL;
using MyBackendProject.DTO;
using MyBackendProject.Models;

namespace MyBackendProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private IEnrollment _enrollment;
        private IMapper _mapper;
        public EnrollmentController(IEnrollment enrollment, IMapper mapper)
        {
            _enrollment = enrollment;
            _mapper = mapper;
        }


        private AppDbContext _dbcontext;

        [HttpGet]
        public IEnumerable<Enrollment> Get()
        {
            var results = _enrollment.GetAll();
            var lstenrollments = _mapper.Map<IEnumerable<Enrollment>>(results);
            return lstenrollments;
        }

        [HttpPost("WithCourse")]
        public IActionResult Enrollment(EnrollmentAddDTO enrollmentDto)
        {
            try
            {
                //_enrollment.Enrollment(enrollmentDto.StudentID, enrollmentDto.CourseID);
                var enrollment = new Enrollment
                {
                    //EnrollmentID = enrollmentDto.EnrollmentID,
                    CourseID = enrollmentDto.CourseID,
                    StudentID = enrollmentDto.StudentID,
                    Grade = enrollmentDto.Grade                
                };

                var newEnrollment = _enrollment.Insert(enrollment);

                var enrollmentGetDto = new EnrollmentGetDTO
                {
                    EnrollmentID = newEnrollment.EnrollmentID,
                    CourseID = newEnrollment.CourseID,
                    StudentID = newEnrollment.StudentID,
                    Grade = newEnrollment.Grade
                };
                return Ok(enrollmentGetDto);

                //return Ok($"StudentID {enrollmentDto.StudentID} berhasil dittambahkan ke Course {enrollmentDto.CourseID}");

                // return CreatedAtAction("Get", new { EnrollmentID = enrollmentDto.EnrollmentID }, enrollmentDto);

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
                var enrollmentGetDto = _mapper.Map<StudentGetDTO>(editEnrollment);
                return Ok(enrollmentGetDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
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


    }
}
