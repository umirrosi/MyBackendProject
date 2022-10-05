using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public IActionResult Enrollment(EnrollmentAddDTO enrollmentDto)
        {
            try
            {
                _enrollment.Enrollment(enrollmentDto.StudentID, enrollmentDto.CourseID);
                return Ok($"StudentID {enrollmentDto.StudentID} berhasil dittambahkan ke Course {enrollmentDto.CourseID}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
