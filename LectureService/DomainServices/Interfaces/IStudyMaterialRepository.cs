using LectureService.Domain;

namespace LectureService.DomainServices.Interfaces
{
    public interface IStudyMaterialRepository
    {
        Task CreateStudyMaterial(StudyMaterial studymaterial);
        Task AddStudyMaterial(StudyMaterial studyMaterial, Guid lectureId);
        Task<List<StudyMaterial>> GetAllStudyMaterialsAsync();
    }
}
