using ProgressService.Domain;
using static ProgressService.Domain.Event.ProgressEvents;

namespace ProgressService.DomainServices.Interfaces
{
    public interface IProgressService
    {
        Task<IEnumerable<Progress>> CreateProgressAsync(Student student);
        Task<IEnumerable<Progress>> CreateProgressAsync(Test test);
    }
}
