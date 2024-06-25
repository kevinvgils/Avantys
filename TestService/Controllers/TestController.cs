using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestService.Domain;
using Model;
using MassTransit;
using TestService.DomainServices.Interfaces;
using System.Collections;

namespace TestService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        // GET: TestController
        private readonly ITestService _testService;
        private readonly ILogger _logger;

        public TestController(ITestService testService, ILogger logger)
        {
            _testService = testService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTest(TestModel test)
        {
            Test createdTest = new Test(test.Module, test.TestDate, test.TeacherId, test.ProctorId);
            return Ok(await _testService.CreateTestAsync(createdTest));
        }

        [HttpGet]
        public async Task<IEnumerable<Test>> getTests() => await _testService.GetAllTestsAsync();


        [HttpPut("{testId}")]
        public async Task<IActionResult> UpdateTest(Guid testId, TestModel test)
        {
            try
            {
                // Create a Test object with the provided data
                Test updatedTest = new Test(test.Module, test.TestDate, test.TeacherId, test.ProctorId);
                updatedTest.Id = testId;

                // Call the service method to update the test
                Test result = await _testService.UpdateTestAsync(updatedTest);

                // Check if the update was successful
                if (result != null)
                {
                    // Log success message if needed
                    _logger.LogInformation($"Test with Id '{testId}' updated successfully.");

                    // Return 200 OK with the updated test object
                    return Ok(result);
                }
                else
                {
                    // Log failure message if needed
                    _logger.LogError($"Failed to update test with Id '{testId}'. Test not found or update operation failed.");

                    // Return 404 Not Found or another appropriate error response
                    return NotFound($"Test with Id '{testId}' not found or update operation failed.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, $"Error updating test with Id '{testId}'.");

                // Return 500 Internal Server Error or another appropriate error response
                return StatusCode(500, $"An error occurred while updating test with Id '{testId}'. Please try again later.");
            }
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteTest(Guid testId)
        {
            return Ok(await _testService.DeleteTestAsync(testId));
        }
    }
}
