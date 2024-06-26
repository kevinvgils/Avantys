using TestService.Domain;
namespace TestService.DomainServices.Interfaces
{
    public interface ITestRepository
    {
        Task CreateTest(Test test);
        Task<Test> GetTest(Guid testId);
        Task<IEnumerable<Test>> GetAllTests();
        Task<Test> UpdateTest(Test test);
        Task DeleteTest(Guid testId);
    }
}
