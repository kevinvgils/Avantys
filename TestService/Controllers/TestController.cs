using DomainServices;
using EventLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestService.Domain;
using Model;
using MassTransit;

namespace TestService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        // GET: TestController
        private readonly ITestRepository _testRepository;
        private readonly IBus _IBus;

        public TestController(IBus bus, ITestRepository testRepository)
        {
            _testRepository = testRepository;
            _IBus = bus;
        }

        [HttpGet]
        public IEnumerable<Test> GetTests()
        {
            return _testRepository.getAllTests();
        }

        [HttpGet("{testId}")]
        public Test GetTest(int testId)
        {
            return _testRepository.getTest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTest(TestModel test)
        {
            Test createdTest = new Test(test.Module, test.TestDate, test.TeacherId, test.ProctorId);

            await _testRepository.createTest(createdTest);

            TestCreated testCreated = new();
            testCreated.TestId = createdTest.Id;
            testCreated.Module = createdTest.Module;

            await _IBus.Publish(testCreated);
            return Ok();
        }
    }
}
