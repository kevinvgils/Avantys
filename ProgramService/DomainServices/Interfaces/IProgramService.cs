using ProgramService.Domain;

namespace ProgramService.DomainServices.Interfaces
{
    public interface IProgramService
    {
        IEnumerable<StudyProgram> GetAllPrograms();

        Task CreateProgram(StudyProgram program);
    }
}
