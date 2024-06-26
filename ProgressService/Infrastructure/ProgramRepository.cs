using EventLibrary;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
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
            await _context.SaveChangesAsync();

            return programToAdd;
        }

        public IEnumerable<StudyProgram> GetAllPrograms()
        {
            try
            {
                // Ensure that the query correctly handles the Subjects property
                IEnumerable<StudyProgram> studyPrograms = _context.StudyPrograms.ToList();

                return studyPrograms;
            }
            catch (Exception ex)
            {
                // Log the exception with more details
                Console.WriteLine($"Error fetching programs in repo: {ex.Message}");
                throw;
            }
        }

        public StudyProgram GetPrograms(Guid programId)
        {
            return _context.StudyPrograms.FirstOrDefault(x => x.Id == programId);
        }
    }
}
