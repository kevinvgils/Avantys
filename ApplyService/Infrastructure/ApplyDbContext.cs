using ApplyService.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApplyService.Infrastructure
{
    public class ApplyDbContext : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; } = null!;
        public ApplyDbContext(DbContextOptions<ApplyDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
