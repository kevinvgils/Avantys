using StudentService.Domain;

namespace StudentService.DomainServices.Interfaces
{
    public interface IStudentRepository
    {
        Student GetStudent();

        Task AddStudent(Student student);
    }
}
