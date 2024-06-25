using Eventlibrary;

namespace ProgressService.DomainServices.Interfaces
{
    public interface IProgramRepository
    {
        IEnumerable<StudyProgram> GetAllPrograms();
        Task<StudyProgram> CreateProgram(StudyProgram Program);
    }
}
