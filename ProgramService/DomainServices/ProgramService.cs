using ProgramService.Domain;
using ProgramService.DomainServices.Interfaces;

namespace ProgramService.DomainServices
{
    public class ProgramService : IProgramService
    {
        public Task CreateProgram(StudyProgram program)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudyProgram> GetAllPrograms()
        {
            throw new NotImplementedException();
        }
    }
}
