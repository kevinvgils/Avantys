using ClassService.Domain;

namespace ClassService.DomainServices.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> AssignStudentToClassAsync(Student student);
        Task<Student> GetStudentByIdAsync(Guid studentId);

    }
}
