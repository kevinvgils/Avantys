using System.Collections.Generic;
using System.Threading.Tasks;
using TeacherService.Domain;


namespace DomainServices
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachers();
        Task<Teacher> GetTeacherById(int id);
        Task AddTeacher(Teacher teacher);
        Task UpdateTeacher(Teacher teacher);
        Task DeleteTeacher(int id);
        
    }
}
