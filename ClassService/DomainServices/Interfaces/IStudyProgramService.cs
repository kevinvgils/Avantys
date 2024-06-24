using ClassService.Domain;

namespace ClassService.DomainServices.Interfaces
{
    public interface IStudyProgramService
    {
        Task<StudyProgram> CreateStudyProgramAsync(StudyProgram studyProgram);
    }
}
