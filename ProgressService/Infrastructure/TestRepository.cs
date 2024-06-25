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


        public async Task<Test> CreateTest(TestCreated Test)
        {
            Test test = new Test(Test.Id, Test.Module);
            await _context.Tests.AddAsync(test);
            await _context.SaveChangesAsync();
            return test;
        }

        public IEnumerable<Test> GetAllTests()
        {
            return _context.Tests.ToList();
        }

        public IEnumerable<Test> GetAllTests(IEnumerable<string> subjects)
        {
            return _context.Tests
                   .Where(test => subjects.Contains(test.Module))
                   .ToImmutableArray();
        }

        public async Task<Test> DeleteTest(TestDeleted Test)
        {
            Test testToDelete = new Test(Test.Id, null);
            _context.Tests.Remove(testToDelete);
            await _context.SaveChangesAsync();
            return new Test(testToDelete.Id, null);
        }

        public async Task<Test> UpdateTest(TestUpdated Test)
        {
            Test foundTest = await _context.Tests.FirstOrDefaultAsync(x => x.Id == Test.Id);


            if (foundTest != null)
            {
                Test newTest = new Test(foundTest.Id, foundTest.Module);
                foundTest = newTest;

                await _context.SaveChangesAsync();
                return new Test(foundTest.Id, foundTest.Module);
            }

            return null;
        }
    }
}
