using ClassService.Domain;

namespace ClassService.DomainServices.Interfaces
{
    public interface IStudyProgramRepository
    {
        Task AddStudyProgram(StudyProgram studyProgram);
        Task<bool> ExistsAsync(Guid studyProgramId);
    }
}
