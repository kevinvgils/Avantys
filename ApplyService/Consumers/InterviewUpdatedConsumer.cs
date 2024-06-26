using System;
using System.Threading.Tasks;
using ApplyService.Domain;
using ApplyService.DomainServices.Interfaces;
using EventLibrary;
using MassTransit;

namespace ApplyService.Consumers
{
    public class InterviewUpdatedConsumer : IConsumer<InterviewUpdated>
    {
        private readonly IApplyService _applyService;
        private readonly IEventStoreRepository _eventStore;

        public InterviewUpdatedConsumer(IApplyService applyService, IEventStoreRepository eventStore)
        {
            _applyService = applyService;
            _eventStore = eventStore;
        }

        public async Task Consume(ConsumeContext<InterviewUpdated> context)
        {
            var @event = context.Message;
            Console.WriteLine("INTERVIEW UPDATED:  " + @event.ApplicantId);
            var applicantToUpdate = await _applyService.GetApplicantByIdAsync(@event.ApplicantId);

            applicantToUpdate.ApplyEvent(@event);

            await _eventStore.SaveEventAsync(@event);
            Console.WriteLine("INTERVIEW UPDATED 2:  " + @event.ApplicantId);
            Console.WriteLine("INTERVIEW UPDATED 3:  " + applicantToUpdate.ApplicantId);

            await _applyService.UpdateApplicantAsync(@event.ApplicantId, applicantToUpdate);
        }
    }
}
