using ProgramService.Domain;

namespace ProgramService.DomainServices.Interfaces
{
    public interface IProgramRepository
    {
        IEnumerable<StudyProgram> GetAllPrograms();

        Task CreateProgram(StudyProgram program);
    }
}
