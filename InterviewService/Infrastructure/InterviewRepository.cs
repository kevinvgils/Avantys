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

        public async Task<List<Interview>> GetAllInterviews()
        {
            return await _context.Interviews.ToListAsync();
        }

        public async Task<Interview> GetInterviewByApplicantId(Guid applicantId)
        {
            return await _context.Interviews.FirstOrDefaultAsync(interview => interview.ApplicantId == applicantId);
        }

        public async Task<Interview> GetInterviewById(Guid id)
        {
            return await _context.Interviews.FirstOrDefaultAsync(interview => interview.InterviewId == id);
        }

        public async Task UpdateInterview(Interview interview)
        {
            _context.Interviews.Update(interview);
            await _context.SaveChangesAsync();
        }
    }
}
