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
    public class CourseController : ControllerBase
    {
        private ICourse _course;
        private IMapper _mapper;
        private CourseGetDTO courseGetDto;

        public CourseController(ICourse course, IMapper mapper)
        {
            _course = course;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CourseGetDTO> Get()
        {
            var results = _course.GetAll();
            var lstCourseGetDto = _mapper.Map<IEnumerable<CourseGetDTO>>(results);
            return lstCourseGetDto;

            //List<CourseGetDTO> lstCourseGetDto = new List<CourseGetDTO>();
            //var results = _course.GetAll();
            //foreach (var c in results)
            //{
            //    lstCourseGetDto.Add(new CourseGetDTO
            //    {
            //        CourseID = c.CourseID,
            //        Title = c.Title,
            //        Credits = c.Credits
            //    });
            //}
            //return lstCourseGetDto;
        }

        [HttpGet("CourseID")]
        public CourseGetDTO Get(int CourseID)
        {
            var result = _course.GetByCourseId(CourseID);
            var courseGetDto = _mapper.Map<CourseGetDTO>(result);
            return courseGetDto;
        }

        [HttpGet("ByTitle")]
        public IEnumerable<CourseGetDTO> GetByTitle(string title)
        {
            var results = _course.GetByTitle(title);
            var listCourseGetDto = _mapper.Map<IEnumerable<CourseGetDTO>>(results);
            return listCourseGetDto;

            //List<CourseGetDTO> listCourseGetDto = new List<CourseGetDTO>();
            //var results = _course.GetByTitle(title);

            //foreach (var r in results)
            //{
            //    listCourseGetDto.Add(new CourseGetDTO
            //    {
            //        CourseID = r.CourseID,
            //        Title = r.Title,
            //        Credits = r.Credits
            //    });
            //}
            //return listCourseGetDto;
        }


        //[HttpGet("credit")]
        //public CourseGetDTO GetByCredit(int credit)
        //{
        //    var result = _course.GetByCredit(credit);
        //    var courseDto = _mapper.Map<CourseGetDTO>(result);
        //    return courseDto;
        //}

        [HttpPost]
        public IActionResult Post(CourseAddDTO courseDto)
        {
            try
            {
                var course = _mapper.Map<Course>(courseDto);
                var newCourse = _course.Insert(course);

                var courseGetDto = _mapper.Map<CourseGetDTO>(newCourse);
                return Ok(courseGetDto);

                //var course = new Course
                //{
                //    CourseID = courseDto.CourseID,
                //    Title = courseDto.Title,
                //    Credits = courseDto.Credits                
                //};

                //var newCourse = _course.Insert(course);

                //var courseGetDto = new CourseGetDTO
                //{
                //    CourseID = newCourse.CourseID,
                //    Title = newCourse.Title,
                //    Credits = newCourse.Credits
                //};
                //return Ok(courseGetDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(CourseAddDTO courseDto)
        {
            try
            {
                var course = _mapper.Map<Course>(courseDto);
                var editCourse = _course.Update(course);
                var courseGetDto = _mapper.Map<CourseGetDTO>(editCourse);
                return Ok(courseGetDto);

                //var course = new Course
                //{
                //    CourseID = courseDto.CourseID,
                //    Title = courseDto.Title,
                //    Credits = courseDto.Credits
                //};

                //var editStudent = _course.Update(course);

                //CourseGetDTO courseGetDto = new CourseGetDTO
                //{
                //    CourseID = courseDto.CourseID,
                //    Title = courseDto.Title,
                //    Credits = courseDto.Credits
                //};

                //return Ok(courseGetDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        public IActionResult Delete(int courseID)
        {
            try
            {
                _course.Delete(courseID);
                return Ok($"Delete id {courseID} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
