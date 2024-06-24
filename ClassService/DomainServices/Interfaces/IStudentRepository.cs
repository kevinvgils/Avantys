using ClassService.Domain;

namespace ClassService.DomainServices.Interfaces
{
    public interface IStudentRepository
    {
        Student GetStudent();

        Task AddStudent(Student student);
    }
}
