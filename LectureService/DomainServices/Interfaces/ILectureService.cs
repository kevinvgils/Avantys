using LectureService.Domain;

namespace LectureService.DomainServices.Interfaces
{
    public interface ILectureService
    {
        Task<Lecture> CreateLectureAsync(Lecture lecture);
        Task<StudyMaterial> CreateStudyMaterialAsync(StudyMaterial studyMaterial, Guid lectureId);
        Task<Lecture> GetLectureByIdAsync(Guid id);
        Task<List<Lecture>> GetAllLecturesAsync();
        Task AddClass(Guid classId, Guid lectureId);
    }
}
