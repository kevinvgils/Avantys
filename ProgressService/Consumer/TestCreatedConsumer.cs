using MassTransit;
using ProgressService.Domain;
using ProgressService.DomainServices.Interfaces;
using Eventlibrary;

namespace ProgressService.Consumer
{
    public class TestCreatedConsumer : IConsumer<Test>
    {
        private readonly ITestRepository _TestRepository;
        private readonly IProgressService _progressService;

        public TestCreatedConsumer(IProgressService progressService, ITestRepository testRepository)
        {
            _progressService = progressService;
            _TestRepository = testRepository;
        }
        public Task Consume(ConsumeContext<Test> context)
        {
            Test test = new Test(context.Message.Id, context.Message.Module);
            _TestRepository.createTest(test);
            _progressService.CreateProgressAsync(test);
           
            Console.WriteLine("CONSUME");

            return Task.CompletedTask;
        }
    }
}
