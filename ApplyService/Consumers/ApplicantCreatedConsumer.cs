using ApplyService.Domain;
using ApplyService.DomainServices.Interfaces;
using EventLibrary;
using MassTransit;

namespace ApplyService.Consumers
{
    public class ApplicantCreatedConsumer : IConsumer<ApplicantCreated>
    {
        private readonly IApplyRepository _applyRepository;

        public ApplicantCreatedConsumer(IApplyRepository applyRepository)
        {
            _applyRepository = applyRepository;
        }

        public async Task Consume(ConsumeContext<ApplicantCreated> context)
        {
            var @event = context.Message;
            var applicant = new Applicant();
            applicant.ApplyEvent(@event);
            await _applyRepository.AddApplicant(applicant);
        }
    }
}