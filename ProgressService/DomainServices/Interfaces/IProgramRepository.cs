using EventLibrary;
using ProgressService.Domain;

namespace ProgressService.DomainServices.Interfaces
{
    public interface IProgramRepository
    {
        IEnumerable<StudyProgram> GetAllPrograms();

        StudyProgram GetPrograms(Guid programId);

        Task<StudyProgram> CreateProgram(StudyProgramCreated Program);
    }
}
