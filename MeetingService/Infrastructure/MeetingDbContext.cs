using Microsoft.EntityFrameworkCore;
using MeetingService.Domain;



namespace Infrastructure
{
    public class MeetingDbContext : DbContext
    {
        public MeetingDbContext(DbContextOptions<MeetingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Meeting> Meetings { get; set; }
    }
}
