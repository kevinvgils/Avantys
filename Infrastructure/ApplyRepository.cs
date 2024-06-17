using Domain.Users;
using DomainServices;

namespace Infrastructure
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

        public Applicant GetApplicant()
        {
            return _context.Applicants.FirstOrDefault();
        }
    }
}
