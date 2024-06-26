using LectureService.Domain;
using System.Runtime.InteropServices;

namespace LectureService.DomainServices.Interfaces
{
    public interface ILectureRepository
    {
        Task AddLecture(Lecture lecture);

        Task<Lecture> GetLectureById(Guid lectureId);

        Task<List<Lecture>> GetAllLecturesAsync();

        Task<bool> DeleteLectureAsync(Guid lectureId);

        Task<List<Class>> GetAllClassesAsync();

        Task AddClass(Class @class);
        Task AssignClassAsync(Guid classId, Guid lectureId);
    }
}
