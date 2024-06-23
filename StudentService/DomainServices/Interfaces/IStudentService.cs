using StudentService.Domain;

namespace StudentService.DomainServices.Interfaces
{
    public interface IStudentService
    {
        Task<Student> CreateStudentAsync(Student student);
    }
}
