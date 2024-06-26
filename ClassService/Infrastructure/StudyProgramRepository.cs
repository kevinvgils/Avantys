using ClassService.Domain;
using ClassService.DomainServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class StudyProgramRepository : IStudyProgramRepository
    {
        private readonly ClassDbContext _context;

        public StudyProgramRepository(ClassDbContext context)
        {
            _context = context;
        }

        public async Task AddStudyProgram(StudyProgram studyProgram)
        {
            _context.StudyPrograms.Add(studyProgram);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid studyProgramId)
        {
            return await _context.StudyPrograms.AnyAsync(s => s.StudyProgramId == studyProgramId);
        }
    }
}
