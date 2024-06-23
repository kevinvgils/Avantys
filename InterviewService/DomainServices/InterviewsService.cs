using InterviewService.Domain;
using InterviewService.DomainServices.Interfaces;
using MassTransit;

namespace InterviewService.DomainServices
{
    public class InterviewsService(IInterviewRepository repo, IBusControl serviceBus) : IInterviewService
    {
        public async Task<Interview> CreateInterviewAsync(Interview interview)
        {
            await repo.CreateInterview(interview);

            return interview;
        }

        public Task<Interview> UpdateInterviewAsync(Guid id, Interview interview)
        {
            throw new NotImplementedException();
        }
    }
}
