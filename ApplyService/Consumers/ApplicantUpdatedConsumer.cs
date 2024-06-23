using System.Threading.Tasks;
using ApplyService.Domain;
using ApplyService.DomainServices.Interfaces;
using EventLibrary;
using MassTransit;

namespace ApplyService.Consumers
{
    public class ApplicantUpdatedConsumer : IConsumer<ApplicantUpdated>
    {
        private readonly IApplyRepository _applyRepository;

        public ApplicantUpdatedConsumer(IApplyRepository applyRepository)
        {
            _applyRepository = applyRepository;
        }

        public async Task Consume(ConsumeContext<ApplicantUpdated> context)
        {
            var @event = context.Message;
            var applicant = new Applicant();

            applicant.ApplyEvent(@event);

            await _applyRepository.UpdateApplicant(applicant);
        }
    }
}
