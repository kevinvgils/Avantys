using MassTransit;
using ProgressService.Domain;
using ProgressService.DomainServices.Interfaces;
using EventLibrary;

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
            TestCreated test = new TestCreated(context.Message.Id, context.Message.Module);
            _TestRepository.createTest(test);
            _progressService.CreateProgressAsync(test);
           
            Console.WriteLine("CONSUME Test");

            return Task.CompletedTask;
        }
    }
}
