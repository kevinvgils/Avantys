using Infrastructure;
using Microsoft.EntityFrameworkCore;
using ProgramService.Domain;
using ProgramService.DomainServices.Interfaces;

namespace Infrastructure
{
    public class ProgramRepository : IProgramRepository
    {
        ProgramDbContext _dbContext;

        ProgramRepository(ProgramDbContext context) => _dbContext = context;

        public async Task CreateProgram(StudyProgram program)
        {
            await _dbContext.Programs.AddAsync(program);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<StudyProgram> GetAllPrograms()
        {
            throw new NotImplementedException();
        }
    }
}
