using Microsoft.EntityFrameworkCore;
using TestService.Domain;
using TestService.DomainServices.Interfaces;

namespace Infrastructure
{
    public class TestRepository : ITestRepository
    {
        private readonly TestDbContext _context;
        private readonly ILogger<TestRepository> _logger;   

        public TestRepository(TestDbContext context, ILogger<TestRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task CreateTest(Test test)
        {
            _context.Tests.Add(test);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTest(Guid testId)
        {
            try
            {
                // Retrieve the test to be deleted
                var test = await GetTest(testId);

                if (test != null)
                {
                    // Remove the test from the context
                    _context.Tests.Remove(test);

                    // Save the changes to the database
                    await _context.SaveChangesAsync();

                    // Log a success message
                    _logger.LogInformation($"Test with Id '{testId}' deleted successfully.");
                }
                else
                {
                    // Log a warning if the test was not found
                    _logger.LogWarning($"Test with Id '{testId}' not found.");
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during the deletion process
                _logger.LogError(ex, $"Error deleting test with Id '{testId}'.");
                throw; // Re-throw the exception to propagate it upwards for handling
            }
        }


        public async Task<IEnumerable<Test>> GetAllTests()
        {
            return await _context.Tests.ToListAsync();
        }

        public async Task<Test> GetTest(Guid testId)
        {
            try
            {
                // Find the test with the specified ID
                var test = await _context.Tests.FirstOrDefaultAsync(t => t.Id == testId);

                // Log a message if the test was found or not
                if (test != null)
                {
                    _logger.LogInformation($"Test with Id '{testId}' retrieved successfully.");
                }
                else
                {
                    _logger.LogWarning($"Test with Id '{testId}' not found.");
                }

                return test;
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during the retrieval process
                _logger.LogError(ex, $"Error retrieving test with Id '{testId}'.");
                throw; // Re-throw the exception to propagate it upwards for handling
            }
        }


        public async Task<Test> UpdateTest(Test test)
        {
            var existingTest = await _context.Tests.FirstOrDefaultAsync(x => x.Id == test.Id);

            if (existingTest != null)
            {
                // Update properties
                existingTest.Module = test.Module;
                existingTest.TestDate = test.TestDate;
                existingTest.TeacherId = test.TeacherId;
                existingTest.ProctorId = test.ProctorId;

                await _context.SaveChangesAsync();
                return existingTest;
            }
            return null;
        }

    }
}
