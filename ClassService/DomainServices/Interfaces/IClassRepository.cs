using ClassService.Domain;

namespace ClassService.DomainServices.Interfaces
{
    public interface IClassRepository
    {
        Task AddClass(Class @class);
        Task<bool> ExistsAsync(Guid classId);
        Task<Class> GetByIdAsync(Guid classId);
    }
}
