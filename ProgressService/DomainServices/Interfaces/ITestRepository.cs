using ProgressService.Domain;
using EventLibrary;

namespace ProgressService.DomainServices.Interfaces
{
    public interface ITestRepository
    {
        IEnumerable<TestCreated> GetAllTests();

        IEnumerable<TestCreated> GetAllTests(IEnumerable<string> subjects);

        Task<TestCreated> CreateTest(TestCreated Test);
    }
}
