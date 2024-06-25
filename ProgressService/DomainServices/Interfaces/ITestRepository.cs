using ProgressService.Domain;
using Eventlibrary;

namespace ProgressService.DomainServices.Interfaces
{
    public interface ITestRepository
    {
        IEnumerable<Test> getAllTests();

        IEnumerable<Test> getAllTests(IEnumerable<string> subjects);

        Task<Test> createTest(Test Test);
    }
}
