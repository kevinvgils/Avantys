using Domain.Events;
using MassTransit;

namespace InterviewService.Consumers
{
    public class ApplyConsumer : IConsumer<IApplicantCreatedEvent>
    {
        public Task Consume(ConsumeContext<IApplicantCreatedEvent> context)
        {
            Console.WriteLine(context.Message.Name);

            return Task.CompletedTask;
        }
    }
}