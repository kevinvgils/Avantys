using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection.Emit;

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
