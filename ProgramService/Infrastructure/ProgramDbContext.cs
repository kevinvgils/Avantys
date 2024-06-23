using Microsoft.EntityFrameworkCore;
using ProgramService.Domain;

namespace Infrastructure
{
    public class ProgramDbContext : DbContext
    {
        public DbSet<StudyProgram> Programs { get; set; } = null!;
        public ProgramDbContext(DbContextOptions<ProgramDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
