﻿using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<IEnumerable<Test>> getTests() => await _testService.GetAllTestsAsync();

        [HttpPut()]
        public async Task<IActionResult> UpdateTest(Guid testId,TestModel test)
        {
            Test createdTest = new Test(test.Module, test.TestDate, test.TeacherId, test.ProctorId);
            createdTest.Id = testId;
            return Ok(await _testService.UpdateTestAsync(createdTest));
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteTest(Guid testId)
        {
            return Ok(await _testService.DeleteTestAsync(testId));
        }
    }
}
