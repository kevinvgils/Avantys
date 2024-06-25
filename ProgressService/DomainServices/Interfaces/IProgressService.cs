using ProgressService.Domain;
using EventLibrary;

namespace ProgressService.DomainServices.Interfaces
{
    public interface IProgressService
    {
        Task<IEnumerable<Progress>> CreateProgressAsync(Student student);
        Task<IEnumerable<Progress>> CreateProgressAsync(Test test);

        Task<IEnumerable<Progress>> DeleteProgressAsync(Test test);
        Task<IEnumerable<Progress>> DeleteProgressAsync(Student student);
    }
}
