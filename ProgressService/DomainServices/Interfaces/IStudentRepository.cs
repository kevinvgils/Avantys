using ProgressService.Domain;
using static ProgressService.Domain.Event.ProgressEvents;

namespace ProgressService.DomainServices.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> getAllStudents();
        Task<Student> createStudent(Student Student);
    }
}
