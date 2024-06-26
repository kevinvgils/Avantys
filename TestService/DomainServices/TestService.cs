using MassTransit;
using Microsoft.AspNetCore.Http.HttpResults;
using TestService.Domain;
using EventLibrary;
using TestService.DomainServices.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace ProgressService.DomainServices
{
    public class TestService : ITestService
    {
        public ITestRepository TestRepository { get; set; }
        public IBus _bus { get; set; }
        private readonly ILogger<TestService> _logger;

        public TestService(ITestRepository repo, IBus serviceBus, ILogger<TestService> logger)
        {
            TestRepository = repo;
            _bus = serviceBus;
            _logger = logger;
        }

        public async Task<Test> CreateTestAsync(Test test)
        {
            try
            {
                await TestRepository.CreateTest(test);
            }
            catch (Exception ex) {
                return null;
            }

            TestCreated testCreated = new();
            testCreated.Id = test.Id;
            testCreated.Module = test.Module;

            await _bus.Publish(testCreated);
            return test;
        }

        public async Task<Test> UpdateTestAsync(Test test)
        {
            try
            {
                // Update the test in the repository
                Test returnedTest = await TestRepository.UpdateTest(test);

                // Log success message
                _logger.LogInformation($"Test with Id '{test.Id}' updated successfully.");

                // Publish TestCreated event
                TestUpdated testUpdated = new TestUpdated
                {
                    Id = test.Id,
                    Module = test.Module
                };
                await _bus.Publish(testUpdated);

                return returnedTest;
            }

            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, $"Error updating test with Id '{test.Id}'.");

                // Return null or throw the exception based on your error handling strategy
                throw; // Re-throwing the exception to propagate it upwards for handling
            }
        }

        public async Task<Test> DeleteTestAsync(Guid testId)
        {
            Test testToDelete = await TestRepository.GetTest(testId);
            try
            {
                // Update the test in the repository
                await TestRepository.DeleteTest(testId);

                // Log success message
                _logger.LogInformation($"Test with Id '{testId}' deleted successfully.");

                // Publish TestCreated event
                TestDeleted testDeleted = new TestDeleted
                {
                    Id = testToDelete.Id,
                };
                await _bus.Publish(testDeleted);

                return testToDelete;
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, $"Error updating test with Id '{testToDelete.Id}'.");

                // Return null or throw the exception based on your error handling strategy
                throw; // Re-throwing the exception to propagate it upwards for handling
            }
        }

        public async Task<IEnumerable<Test>> GetAllTestsAsync() => await TestRepository.GetAllTests();
    }
}
