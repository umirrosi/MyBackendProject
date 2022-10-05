using Microsoft.EntityFrameworkCore;
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
    }
}
