using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestService.Domain;
using Model;
using MassTransit;
using TestService.DomainServices.Interfaces;

namespace TestService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        // GET: TestController
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTest(TestModel test)
        {
            Test createdTest = new Test(test.Module, test.TestDate, test.TeacherId, test.ProctorId);
            return Ok(await _testService.CreateTestAsync(createdTest));
        }
    }
}
