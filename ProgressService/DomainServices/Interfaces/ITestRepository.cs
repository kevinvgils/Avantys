using ProgressService.Domain;

namespace TestService.DomainServices.Interfaces
{
    public interface ITestRepository
    {
        IEnumerable<Test> getAllTests();
        Task<Test> createTest(Test Test);
    }
}
