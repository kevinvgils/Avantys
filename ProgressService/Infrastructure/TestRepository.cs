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


        public async Task<TestCreated> CreateTest(TestCreated Test)
        {
            await _context.Tests.AddAsync(Test);
            await _context.SaveChangesAsync();
            return Test;
        }

        public IEnumerable<TestCreated> GetAllTests()
        {
            return _context.Tests.ToList();
        }

        public IEnumerable<TestCreated> GetAllTests(IEnumerable<string> subjects)
        {
            return _context.Tests
                   .Where(test => subjects.Contains(test.Module))
                   .ToImmutableArray();
        }
    }
}
