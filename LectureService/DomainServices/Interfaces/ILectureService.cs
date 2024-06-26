using LectureService.Domain;

namespace LectureService.DomainServices.Interfaces
{
    public interface ILectureService
    {
        Task<Lecture> CreateLectureAsync(Lecture lecture);
        Task<List<Lecture>> GetAllLecturesAsync();
        Task<Lecture> GetLectureByIdAsync(Guid id);
        Task<bool> DeleteLectureAsync(Guid lectureId);
        Task<StudyMaterial> CreateStudyMaterialAsync(StudyMaterial studyMaterial, Guid lectureId);
        Task<List<StudyMaterial>> GetAllStudyMaterialsAsync();
        Task<List<Class>> GetAllClassesAsync();
        Task AssignClassAsync(Guid classId, Guid lectureId);
    }
}
