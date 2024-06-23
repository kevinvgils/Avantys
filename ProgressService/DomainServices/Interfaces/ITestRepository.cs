using ProgressService.Domain;
using static ProgressService.Domain.Event.ProgressEvents;

namespace ProgressService.DomainServices.Interfaces
{
    public interface ITestRepository
    {
        IEnumerable<Test> getAllTests();
        Task<Test> createTest(Test Test);
    }
}
