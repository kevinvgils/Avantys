using Eventlibrary;
using ProgressService.Domain;

namespace ProgressService.DomainServices.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> getAllStudents();

        IEnumerable<Student> getAllStudents(string module);

        Task<Student> createStudent(Student Student);
    }
}
