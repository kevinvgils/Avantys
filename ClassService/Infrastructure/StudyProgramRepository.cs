using ClassService.Domain;
using ClassService.DomainServices.Interfaces;

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
    }
}
