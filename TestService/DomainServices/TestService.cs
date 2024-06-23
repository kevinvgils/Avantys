using EventLibrary;
using MassTransit;
using Microsoft.AspNetCore.Http.HttpResults;
using TestService.Domain;
using TestService.DomainServices.Interfaces;

namespace ProgressService.DomainServices
{
    public class TestService : ITestService
    {
        public ITestRepository TestRepository { get; set; }
        public IBusControl BusControl { get; set; }

        public TestService(ITestRepository repo, IBusControl serviceBus)
        {
            TestRepository = repo;
            BusControl = serviceBus;
        }

        public async Task<Test> CreateTestAsync(Test test)
        {
            TestCreated testCreated = new();
            testCreated.TestId = test.Id;
            testCreated.Module = test.Module;

            await BusControl.Publish(test);
            return test;
        }
    }
}
