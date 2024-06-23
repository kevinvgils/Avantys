using InterviewService.Domain;
using Microsoft.EntityFrameworkCore;

namespace InterviewService.Infrastructure
{
    public class InterviewDbContext : DbContext
    {
        public DbSet<Interview> Interviews { get; set; } = null!;
        public InterviewDbContext(DbContextOptions<InterviewDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
