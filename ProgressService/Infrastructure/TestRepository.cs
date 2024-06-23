using Eventlibrary;
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


        public async Task<Test> createTest(Test Test)
        {
            await _context.Tests.AddAsync(Test);
            return Test;
        }

        public IEnumerable<Test> getAllTests()
        {
            return _context.Tests.ToImmutableArray();
        }
    }
}
