using ClassService.Domain;
using ClassService.DomainServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ClassRepostitory : IClassRepository
    {
        private readonly ClassDbContext _context;

        public ClassRepostitory(ClassDbContext context)
        {
            _context = context;
        }

        public async Task AddClass(Class @class)
        {
            _context.Classes.Add(@class);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid classId)
        {
            return await _context.Classes.AnyAsync(c => c.ClassId == classId);
        }
        public async Task<Class> GetByIdAsync(Guid classId)
        {
            return await _context.Classes.FindAsync(classId);
        }
    }
}
