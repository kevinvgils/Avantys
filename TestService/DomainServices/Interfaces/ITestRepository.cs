using TestService.Domain;
namespace TestService.DomainServices.Interfaces
{
    public interface ITestRepository
    {
        Task createTest(Test test);

        Test getTest();

        IEnumerable<Test> getAllTests();
    }
}
