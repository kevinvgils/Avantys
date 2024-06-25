using ClassService.Domain;

namespace ClassService.DomainServices.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetStudent(Guid studentId);
        Task UpdateStudent(Student updatedStudent);

        Task<List<Student>> GetAllStudents();

        Task AddStudent(Student student);
    }
}
