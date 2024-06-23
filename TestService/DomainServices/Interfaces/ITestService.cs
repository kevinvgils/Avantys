using TestService.Domain;

namespace TestService.DomainServices.Interfaces
{
    public interface ITestService
    {
        Task<Test> CreateTestAsync(Test test);
    }
}
