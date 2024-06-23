using InterviewService.Domain;

namespace InterviewService.DomainServices.Interfaces
{
    public interface IInterviewService
    {
        Task<Interview> CreateInterviewAsync(Interview interview);
        Task<Interview> UpdateInterviewAsync(Guid id, Interview updatedInterview);
        Task<Interview> GetInterviewByIdAsync(Guid id);

    }
}
