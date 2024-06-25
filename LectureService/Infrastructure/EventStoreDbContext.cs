using LectureService.Domain;
using Microsoft.EntityFrameworkCore;

namespace LectureService.Infrastructure
{
    public class EventStoreDbContext : DbContext
    {
        public DbSet<EventStore> EventStores { get; set; } = null!;
        public EventStoreDbContext(DbContextOptions<EventStoreDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
