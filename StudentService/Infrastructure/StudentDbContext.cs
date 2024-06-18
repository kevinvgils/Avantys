using Microsoft.EntityFrameworkCore;
using StudentService.Domain;

namespace Infrastructure
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
