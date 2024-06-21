using TestService.Domain;
namespace DomainServices
{
    public interface ITestRepository
    {
        Task createTest(Test test);

        Test getTest();

        IEnumerable<Test> getAllTests();
    }
}
