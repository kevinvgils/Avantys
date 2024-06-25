using TestService.Domain;
namespace TestService.DomainServices.Interfaces
{
    public interface ITestRepository
    {
        Task CreateTest(Test test);
        Test GetTest(Guid testId);
        Task<IEnumerable<Test>> GetAllTests();
        Task UpdateTest(Test test);
        Task DeleteTest(Guid testId);
    }
}
