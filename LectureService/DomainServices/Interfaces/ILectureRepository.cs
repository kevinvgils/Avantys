using LectureService.Domain;
using System.Runtime.InteropServices;

namespace LectureService.DomainServices.Interfaces
{
    public interface ILectureRepository
    {
        Task AddLecture(Lecture lecture);

        Task<Lecture> GetLectureById(Guid lectureId);

        Task<List<Lecture>> GetAllLecturesAsync();

        Task AddClass(Guid classId, Guid lectureId);

        Task<Guid?> GetClass(Guid lectureId);
    }
}
