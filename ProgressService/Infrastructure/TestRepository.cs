using ProgressService.Domain;
using EventLibrary;
using ProgressService.DomainServices.Interfaces;
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;

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

        public async Task<TestDeleted> DeleteTest(TestDeleted Test)
        {
            TestCreated testToDelete = new TestCreated(Test.Id, null);
            _context.Tests.Remove(testToDelete);
            await _context.SaveChangesAsync();
            return new TestDeleted(testToDelete.Id);
        }

        public async Task<TestUpdated> UpdateTest(TestUpdated Test)
        {
            TestCreated foundTest = await _context.Tests.FirstOrDefaultAsync(x => x.Id == Test.Id);


            if (foundTest != null)
            {
                TestCreated newTest = new TestCreated(foundTest.Id, foundTest.Module);
                foundTest = newTest;

                await _context.SaveChangesAsync();
                return new TestUpdated(foundTest.Id, foundTest.Module);
            }

            return null;
        }
    }
}
