using Microsoft.EntityFrameworkCore;
using ProgressService.Domain;

namespace Infrastructure
{
    public class ProgressDbContext : DbContext
    {
        public DbSet<Progress> Progress { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Test> Tests { get; set; } = null!;

        public ProgressDbContext(DbContextOptions<ProgressDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
