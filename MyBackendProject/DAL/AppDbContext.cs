using Microsoft.EntityFrameworkCore;
using MyBackendProject.DTO;
using MyBackendProject.Models;

namespace MyBackendProject.DAL
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<CourseStudent>()
        //        .HasKey(cs => new { cs.StudentID, cs.CourseID });
        //    builder.Entity<CourseStudent>()
        //        .HasKey(cs => cs.Student)
        //        .WithMany(cs => cs.courses)
        //        .HasForeignKey(cs => cs.StudentID);
        //    builder.Entity<CourseStudent>()
        //        .HasKey(cs => cs.Course)
        //        .WithMany(cs => cs.students)
        //        .HasForeignKey(cs => cs.CourseID);
        //}
    }
}
