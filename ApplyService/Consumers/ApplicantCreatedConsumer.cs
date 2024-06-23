using ApplyService.Domain;
using ApplyService.DomainServices.Interfaces;
using EventLibrary;
using MassTransit;

namespace ApplyService.Consumers
{
    public class ApplicantCreatedConsumer(IApplyRepository _applyRepository) : IConsumer<ApplicantCreated>
    {
        public Task Consume(ConsumeContext<ApplicantCreated> context)
        {
            var @event = context.Message;
            var applicant = new Applicant();

            applicant.ApplyEvent(@event);

            return _applyRepository.AddApplicant(applicant);
        }
    }
}