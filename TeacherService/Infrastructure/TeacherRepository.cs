using System.Collections.Generic;
using System.Threading.Tasks;
using DomainServices;
using TeacherService.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly TeacherDbContext _context;

        public TeacherRepository(TeacherDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacherById(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task AddTeacher(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTeacher(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
            }
        }
    }
}
