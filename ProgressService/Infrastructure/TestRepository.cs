using EventLibrary;
using ProgressService.Domain;
using ProgressService.DomainServices.Interfaces;
using System.Collections.Immutable;

namespace Infrastructure
{
    public class TestRepository : ITestRepository
    {

        private readonly ProgressDbContext _context;

        public TestRepository(ProgressDbContext context)
        {
            _context = context;
        }


        public async Task<TestCreated> createTest(TestCreated Test)
        {
            await _context.Tests.AddAsync(Test);
            return Test;
        }

        public IEnumerable<TestCreated> getAllTests()
        {
            return _context.Tests.ToImmutableArray();
        }

        public IEnumerable<TestCreated> getAllTests(IEnumerable<string> subjects)
        {
            return _context.Tests
                   .Where(test => subjects.Contains(test.Module))
                   .ToImmutableArray();
        }
    }
}
