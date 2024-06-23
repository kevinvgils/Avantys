using ProgressService.Domain;

namespace ProgressService.DomainServices.Interfaces
{
    public interface IProgressService
    {
        Task<IEnumerable<Progress>> CreateProgressAsync(Student student);
        Task<IEnumerable<Progress>> CreateProgressAsync(Test test);
    }
}
