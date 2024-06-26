using EventLibrary;
using InterviewService.Domain;
using InterviewService.DomainServices.Interfaces;
using InterviewService.Infrastructure;
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

        public async Task<List<Interview>> GetAllInterviewsAsync()
        {
            var interviews = await repo.GetAllInterviews();

            return interviews;
        }

        public async Task<Interview> GetInterviewByApplicantIdAsync(Guid id)
        {
            var interview = await repo.GetInterviewByApplicantId(id);

            return interview;
        }

        public async Task<Interview> GetInterviewByIdAsync(Guid id)
        {
            var interview = await repo.GetInterviewById(id);

            return interview;
        }

        public async Task<Interview> UpdateInterviewAsync(Guid id, Interview updatedInterview)
        {
            var interview = await repo.GetInterviewById(id);
            if (interview == null)
            {
                throw new KeyNotFoundException("Interview not found.");
            }

            interview.Status = updatedInterview.Status;
            interview.Comments = updatedInterview.Comments;

            await repo.UpdateInterview(interview);

            var interviewUpdated = new InterviewUpdated();
            interviewUpdated.ApplicantId = interview.ApplicantId;
            interviewUpdated.InterviewId = interview.InterviewId;
            interviewUpdated.IsAccepted = updatedInterview.Status == "Accepted";

            await serviceBus.Publish(interviewUpdated, context =>
            {
                context.SetRoutingKey("interview.updated");
            });

            return interview;
        }
    }
}
