using LectureService.Domain;

namespace LectureService.DomainServices
{
    public interface IStudyMaterialRepository
    {
        Task AddStudyMaterial(StudyMaterial studyMaterial);

        StudyMaterial GetStudyMaterialById(Guid id);

        StudyMaterial GetAllStudyMaterial();
    }
}
