using DomainServices;
using EventLibrary;
using MassTransit;
using ProgressService.Domain;

namespace ProgressService.Consumer
{
    public class StudentTestConsumer : IConsumer<TestCreated>
    {
        private readonly IProgressRepository _ProgressRepository;

        public StudentTestConsumer(IProgressRepository ProgressRepository)
        {
            _ProgressRepository = ProgressRepository;
        }
        public Task Consume(ConsumeContext<TestCreated> context)
        {

            Progress Progress = new Progress(context.Message.TestId, context.Message.Module, null, null);
            _ProgressRepository.createMultipleProgress(Progress, context.Message.StudentIds);
            Console.WriteLine("CONSUME");

            return Task.CompletedTask;
        }
    }
}
