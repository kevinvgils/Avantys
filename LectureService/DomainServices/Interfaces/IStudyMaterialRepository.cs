using LectureService.Domain;

namespace LectureService.DomainServices.Interfaces
{
    public interface IStudyMaterialRepository
    {
        Task AddStudyMaterial(StudyMaterial studyMaterial, Guid lectureId);

        Task<StudyMaterial> GetStudyMaterialById(Guid studyMaterialId);
    }
}
