using TestService.Domain;
using TestService.DomainServices.Interfaces;

namespace Infrastructure
{
    public class TestRepository : ITestRepository
    {
        private readonly TestDbContext _context;

        public TestRepository(TestDbContext context)
        {
            _context = context;
        }

        public async Task createTest(Test test)
        {
            _context.Tests.Add(test);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Test> getAllTests()
        {
            return _context.Tests.ToList();
        }

        public Test getTest()
        {
            throw new NotImplementedException();
        }
    }
}
