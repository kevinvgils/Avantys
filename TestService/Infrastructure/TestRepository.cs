using Microsoft.EntityFrameworkCore;
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

        public async Task CreateTest(Test test)
        {
            _context.Tests.Add(test);
            await _context.SaveChangesAsync();
        }

        public Task DeleteTest(Guid testId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Test>> GetAllTests()
        {
            return await _context.Tests.ToListAsync();
        }

        public Test GetTest(Guid testId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTest(Test test)
        {
            throw new NotImplementedException();
        }
    }
}
