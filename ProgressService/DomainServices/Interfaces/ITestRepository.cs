using EventLibrary;
using ProgressService.Domain;

namespace ProgressService.DomainServices.Interfaces
{
    public interface ITestRepository
    {
        IEnumerable<Test> GetAllTests();

        IEnumerable<Test> GetAllTests(IEnumerable<string> subjects);

        Task<Test> CreateTest(TestCreated Test);

        Task<Test> UpdateTest(TestUpdated Test);

        Task<Test> DeleteTest(TestDeleted Test);
    }
}
