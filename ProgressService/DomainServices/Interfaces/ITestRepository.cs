using ProgressService.Domain;
using Eventlibrary;

namespace ProgressService.DomainServices.Interfaces
{
    public interface ITestRepository
    {
        IEnumerable<Test> getAllTests();
        Task<Test> createTest(Test Test);
    }
}
