using EventLibrary;
using InterviewService.Domain;
using InterviewService.DomainServices.Interfaces;
using MassTransit;

namespace InterviewService.Consumers
{
    public class ApplicantCreatedConsumer(IInterviewService interviewService) : IConsumer<ApplicantCreated>
    {
        public Task Consume(ConsumeContext<ApplicantCreated> context)
        {
            Console.WriteLine(context.Message.Name);
            var message = context.Message;
            var interview = new Interview();
            interview.ApplyEvent(message);

            interviewService.CreateInterviewAsync(interview);


            return Task.CompletedTask;
        }
    }
}