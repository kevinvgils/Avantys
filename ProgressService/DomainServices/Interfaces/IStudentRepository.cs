using EventLibrary;
using ProgressService.Domain;

namespace ProgressService.DomainServices.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();

        IEnumerable<Student> GetAllStudents(string module);

        Task<Student> CreateStudent(Student Student);
    }
}
