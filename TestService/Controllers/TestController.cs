﻿using DomainServices;
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

        [HttpGet("{testId}")]
        public Test GetTest(int testId)
        {
            return _testRepository.getTest();
        }

        [HttpPost]
        public void CreateTest(Test test)
        {
            _testRepository.createTest(new Test());
        }
    }
}
