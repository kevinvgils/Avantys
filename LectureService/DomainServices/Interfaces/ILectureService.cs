using LectureService.Domain;

namespace LectureService.DomainServices.Interfaces
{
    public interface ILectureService
    {
        Task<Lecture> CreateLectureAsync(Lecture lecture);
        Task<List<Lecture>> GetAllLecturesAsync();
        Task<Lecture> GetLectureByIdAsync(Guid id);
        Task<Lecture> DeleteLectureAsync(Guid id);
        Task<StudyMaterial> CreateStudyMaterialAsync(StudyMaterial studyMaterial, Guid lectureId);
        Task AddClass(Guid classId, Guid lectureId);
    }
}
