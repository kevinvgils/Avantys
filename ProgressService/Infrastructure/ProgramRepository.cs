using EventLibrary;
using Infrastructure;
using ProgressService.Domain;
using ProgressService.DomainServices.Interfaces;
using System.Collections.Immutable;

namespace ProgressService.Infrastructure
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly ProgressDbContext _context;

        public ProgramRepository(ProgressDbContext context)
        {
            _context = context;
        }

        public async Task<StudyProgram> CreateProgram(StudyProgramCreated Program)
        {
            StudyProgram programToAdd = new StudyProgram(Program.StudyProgramId, Program.Name, Program.Subjects);
            await _context.StudyPrograms.AddAsync(programToAdd);
            return programToAdd;
        }

        public IEnumerable<StudyProgram> GetAllPrograms()
        {
            return _context.StudyPrograms.ToImmutableArray();
        }

        public StudyProgram GetPrograms(Guid programId)
        {
            return _context.StudyPrograms.FirstOrDefault(x => x.Id == programId);
        }
    }
}
