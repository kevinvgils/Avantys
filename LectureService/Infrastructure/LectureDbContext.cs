using LectureService.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LectureService.Infrastructure
{
    public class LectureDbContext : DbContext
    {
        public DbSet<Lecture> Lectures { get; set; } = null!;
        public DbSet<StudyMaterial> StudyMaterials { get; set; } = null!;
        public LectureDbContext(DbContextOptions<LectureDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
