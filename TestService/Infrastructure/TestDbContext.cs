using Microsoft.EntityFrameworkCore;
using TestService.Domain;

namespace Infrastructure
{
    public class TestDbContext : DbContext
    {
        public DbSet<Test> Tests { get; set; } = null!;

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
