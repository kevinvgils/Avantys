using InterviewService.Domain;

namespace InterviewService.DomainServices.Interfaces
{
    public interface IInterviewRepository
    {
        Task CreateInterview(Interview interview);

        Task<Interview> GetInterviewById(Guid interviewId);
        Task UpdateInterview(Interview interview);

    }
}
