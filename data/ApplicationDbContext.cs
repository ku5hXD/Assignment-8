using Microsoft.EntityFrameworkCore;
using Assignment_8.Models;

namespace Assignment_8.ApplicationDbContextNamespace
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
    }
}