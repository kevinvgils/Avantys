using TeacherService.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class TeacherDbContext : DbContext
    {
        public TeacherDbContext(DbContextOptions<TeacherDbContext> options)
            : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
    }
}
