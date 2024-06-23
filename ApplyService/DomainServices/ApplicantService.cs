using ApplyService.Domain;
using ApplyService.DomainServices.Interfaces;
using EventLibrary;
using MassTransit;

namespace ApplyService.DomainServices
{
    public class ApplicantService(IApplyRepository repo, IEventStoreRepository eventStore, IBusControl serviceBus) : IApplyService
    {
        public async Task<Applicant> CreateApplicantAsync(Applicant applicant)
        {
            var @event = new ApplicantCreated()
            {
                ApplicantId = Guid.NewGuid(),
                Name = applicant.Name,
                Email = applicant.Email,
            };
            await eventStore.SaveEventAsync(@event);
            await serviceBus.Publish(@event);

            applicant.ApplicantId = @event.ApplicantId;

            return applicant;
        }

        public Task<Applicant> UpdateApplicantAsync(Guid id, Applicant applicant)
        {
            throw new NotImplementedException();
        }
    }
}
