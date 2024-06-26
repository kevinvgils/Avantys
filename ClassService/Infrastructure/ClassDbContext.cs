using Microsoft.EntityFrameworkCore;
using ClassService.Domain;

namespace Infrastructure
{
    public class ClassDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Class> Classes { get; set; } = null!;
        public DbSet<StudyProgram> StudyPrograms { get; set; } = null!;

        public ClassDbContext(DbContextOptions<ClassDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
