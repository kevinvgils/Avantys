using DomainServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestService.Domain;

namespace TestService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        // GET: TestController
        private readonly ITestRepository _testRepository;

        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        [HttpGet]
        public IEnumerable<Test> GetTests()
        {
            return _testRepository.getAllTests();
        }

        [HttpGet]
        public Test GetTest()
        {
            return _testRepository.getTest();
        }

        [HttpPost]
        public void CreateTest()
        {
            _testRepository.createTest(new Test());
        }
    }
}
