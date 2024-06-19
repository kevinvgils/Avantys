using LectureService.Domain;
using System.Runtime.InteropServices;

namespace LectureService.DomainServices
{
    public interface ILectureRepository
    {
        Task AddLecture(Lecture lecture);

        Task<Lecture> GetLectureById(Guid lectureId);

        Task UpdateLecture(Lecture lecture);

        Task AddTeacher(Guid teacherId, Guid lectureId);

        Guid GetTeacher();

        Task AddClass(Guid classId, Guid lectureId);

        Guid GetClass();
    }
}
