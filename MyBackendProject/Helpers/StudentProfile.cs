using AutoMapper;
using MyBackendProject.DTO;
using MyBackendProject.Models;

namespace MyBackendProject.Helpers
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<CourseAddDTO, Course>();
            CreateMap<Course, CourseGetDTO>();

            CreateMap<CourseGetDTO, Course>();

            CreateMap<StudentAddDTO, Student>();
            CreateMap<Student, StudentGetDTO>();

            CreateMap<StudentGetDTO, Student>();
            CreateMap<Student, StudentGetDTO>();

            CreateMap<Enrollment, EnrollmentGetFirstDTO>();
            CreateMap<Enrollment, EnrollmentGetDTO>();
            CreateMap<EnrollmentGetFirstDTO, Enrollment>();

            CreateMap<Enrollment, EnrollmentAddDTO>();
            CreateMap<EnrollmentAddDTO, Enrollment>();

        }
    }
}
