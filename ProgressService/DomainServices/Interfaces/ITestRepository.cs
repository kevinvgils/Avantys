using ProgressService.Domain;
using Eventlibrary;

namespace ProgressService.DomainServices.Interfaces
{
    public interface ITestRepository
    {
        IEnumerable<TestCreated> getAllTests();

        IEnumerable<TestCreated> getAllTests(IEnumerable<string> subjects);

        Task<TestCreated> createTest(TestCreated Test);
    }
}
