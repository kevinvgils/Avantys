using EventLibrary;
using MassTransit;

namespace InterviewService.Consumers
{
    public class ApplicantCreatedConsumer : IConsumer<ApplicantCreated>
    {
        public Task Consume(ConsumeContext<ApplicantCreated> context)
        {
            Console.WriteLine(context.Message.Name);

            return Task.CompletedTask;
        }
    }
}