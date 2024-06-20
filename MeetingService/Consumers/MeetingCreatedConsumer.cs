
using MassTransit;
using EventLibrary;
using MeetingService.Domain;
using MeetingService.DomainServices;

namespace MeetingService.Consumers
{
    public class MeetingCreatedConsumer : IConsumer<MeetingCreated>
    {
        private readonly IMeetingRepository _meetingRepository;

        public MeetingCreatedConsumer(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }
        public Task Consume(ConsumeContext<MeetingCreated> context)
        {

            Meeting meeting = new Meeting(context.Message.StartTime, context.Message.EndTime);
            _meetingRepository.AddMeeting(meeting);
            Console.WriteLine("CONSUME");

            return Task.CompletedTask;
        }

   
    }
}