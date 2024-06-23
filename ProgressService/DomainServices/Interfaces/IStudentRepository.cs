using Eventlibrary;
using ProgressService.Domain;

namespace ProgressService.DomainServices.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> getAllStudents();
        Task<Student> createStudent(Student Student);
    }
}
