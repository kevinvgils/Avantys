using ApplyService.Domain;
using ApplyService.DomainServices.Interfaces;
using ApplyService.Infrastructure;
using EventLibrary;
using MassTransit;

namespace ApplyService.DomainServices
{
    public class ApplicantService : IApplyService
    {
        private readonly IApplyRepository _applyRepository;
        private readonly IEventStoreRepository _eventStore;
        private readonly IBusControl _serviceBus;

        public ApplicantService(IApplyRepository applyRepository, IEventStoreRepository eventStore, IBusControl serviceBus)
        {
            _applyRepository = applyRepository;
            _eventStore = eventStore;
            _serviceBus = serviceBus;
        }

        public async Task<Applicant> CreateApplicantAsync(Applicant applicant)
        {
            var @event = new ApplicantCreated()
            {
                ApplicantId = Guid.NewGuid(),
                Name = applicant.Name,
                Email = applicant.Email,
                StudyProgram = applicant.StudyProgram,
            };
            await _eventStore.SaveEventAsync(@event);
            await _serviceBus.Publish(@event, context =>
            {
                context.SetRoutingKey("applicant.created");
            });

            applicant.ApplicantId = @event.ApplicantId;

            return applicant;
        }

        public Task<Applicant> GetApplicantByIdAsync(Guid id)
        {
            var applicant = _applyRepository.GetApplicantById(id);
            return applicant;
        }
        public Task<List<Applicant>> GetAllApplicantsAsync()
        {
            return _applyRepository.GetAllApplicantsAsync();
        }


        public async Task<Applicant> UpdateApplicantAsync(Guid id, Applicant applicant)
        {
            var @event = new ApplicantUpdated()
            {
                ApplicantId = id,
                Name = applicant.Name,
                Email = applicant.Email,
                IsAccepted = applicant.IsAccepted,
                StudyProgram = applicant.StudyProgram,
            };

            await _eventStore.SaveEventAsync(@event);
            await _serviceBus.Publish(@event, context =>
            {
                context.SetRoutingKey("applicant.updated");
            });

            return applicant;
        }

    }
}
