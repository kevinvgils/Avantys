using InterviewService.Domain;

namespace InterviewService.DomainServices.Interfaces
{
    public interface IInterviewRepository
    {
        Task CreateInterview(Interview interview);
        Task<List<Interview>> GetAllInterviews();
        Task<Interview> GetInterviewById(Guid interviewId);
        Task<Interview> GetInterviewByApplicantId(Guid applicantId);

        Task UpdateInterview(Interview interview);

    }
}
