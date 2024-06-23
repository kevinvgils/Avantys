using InterviewService.Domain;
using InterviewService.DomainServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InterviewService.Infrastructure
{
    public class InterviewRepository : IInterviewRepository
    {
        private readonly InterviewDbContext _context;

        public InterviewRepository(InterviewDbContext context)
        {
            _context = context;
        }

        public async Task CreateInterview(Interview interview)
        {
            _context.Interviews.Add(interview);
            await _context.SaveChangesAsync();
        }

        public Task<Interview> GetInterviewById(Guid interviewId)
        {
            throw new NotImplementedException();
        }
    }
}
