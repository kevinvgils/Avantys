using ClassService.Domain;

namespace ClassService.DomainServices.Interfaces
{
    public interface IClassService
    {
        Task<Class> CreateClassAsync(Class @class);
    }
}
