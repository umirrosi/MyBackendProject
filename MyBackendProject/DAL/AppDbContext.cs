using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBackendProject.DTO;
using MyBackendProject.Models;

namespace MyBackendProject.DAL
{
    public class AppDbContext : IdentityDbContext 
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }

    }
}
