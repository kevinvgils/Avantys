using ClassService.Domain;

namespace ClassService.DomainServices.Interfaces
{
    public interface IStudentService
    {
        Task<Student> CreateStudentAsync(Student student);
    }
}
