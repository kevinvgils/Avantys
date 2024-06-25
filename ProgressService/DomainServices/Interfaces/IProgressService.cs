using ProgressService.Domain;
using EventLibrary;

namespace ProgressService.DomainServices.Interfaces
{
    public interface IProgressService
    {
        Task<IEnumerable<Progress>> CreateProgressAsync(Student student);
        Task<IEnumerable<Progress>> CreateProgressAsync(TestCreated test);

        Task<IEnumerable<Progress>> DeleteProgressAsync(TestCreated test);
    }
}
