using TestService.Domain;

namespace TestService.DomainServices.Interfaces
{
    public interface ITestService
    {
        Task<Test> CreateTestAsync(Test test);
        Task<Test> UpdateTestAsync(Test test);
        Task<Test> DeleteTestAsync(Guid testId);

        Task<IEnumerable<Test>> GetAllTestsAsync();
    }
}
