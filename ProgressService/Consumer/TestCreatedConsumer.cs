using EventLibrary;
using MassTransit;
using ProgressService.Domain;
using ProgressService.DomainServices.Interfaces;
using static ProgressService.Domain.Event.ProgressEvents;

namespace ProgressService.Consumer
{
    public class TestCreatedConsumer : IConsumer<TestCreated>
    {
        private readonly ITestRepository _TestRepository;
        private readonly IProgressService _progressService;

        public TestCreatedConsumer(IProgressService progressService, ITestRepository testRepository)
        {
            _progressService = progressService;
            _TestRepository = testRepository;
        }
        public Task Consume(ConsumeContext<TestCreated> context)
        {
            Test test = new Test(context.Message.TestId, context.Message.Module);
            _TestRepository.createTest(test);
            _progressService.CreateProgressAsync(test);
           
            Console.WriteLine("CONSUME");

            return Task.CompletedTask;
        }
    }
}
