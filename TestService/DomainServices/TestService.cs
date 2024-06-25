using MassTransit;
using Microsoft.AspNetCore.Http.HttpResults;
using TestService.Domain;
using Eventlibrary;
using TestService.DomainServices.Interfaces;

namespace ProgressService.DomainServices
{
    public class TestService : ITestService
    {
        public ITestRepository TestRepository { get; set; }
        public IBus _bus { get; set; }

        public TestService(ITestRepository repo, IBus serviceBus)
        {
            TestRepository = repo;
            _bus = serviceBus;
        }

        public async Task<Test> CreateTestAsync(Test test)
        {
            TestCreated testCreated = new();
            testCreated.Id = test.Id;
            testCreated.Module = test.Module;

            await _bus.Publish(test);
            return test;
        }

        public Task<Test> UpdateTestAsync(Test test)
        {
            throw new NotImplementedException();
        }

        public Task<Test> DeleteTestAsync(Guid testId)
        {
            throw new NotImplementedException();
        }

        public Task<Test> GetAllTestsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
