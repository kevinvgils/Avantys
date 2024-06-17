using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection.Emit;

namespace Infrastructure
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
