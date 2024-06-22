using ApplyService.Domain;
using ApplyService.DomainServices.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace ApplyService.Infrastructure
{
    public class ApplyRepository : IApplyRepository
    {
        private readonly ApplyDbContext _context;

        public ApplyRepository(ApplyDbContext context)
        {
            _context = context;
        }

        public async Task AddApplicant(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            await _context.SaveChangesAsync();
        }

        public async Task<Applicant> GetApplicantById(Guid applicantId)
        {
            return await _context.Applicants.FirstOrDefaultAsync(a => a.ApplicantId == applicantId);
        }
    }
}
