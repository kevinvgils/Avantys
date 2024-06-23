using ApplyService.Domain;
using ApplyService.DomainServices.Interfaces;
using MassTransit;
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

        public async Task<List<Applicant>> GetAllApplicantsAsync()
        {
            return await _context.Applicants.ToListAsync();
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

        public async Task UpdateApplicant(Applicant applicantToUpdate)
        {
            Console.WriteLine(applicantToUpdate.ApplicantId);
            var existingApplicant = await _context.Applicants.FindAsync(applicantToUpdate.ApplicantId);
            if (existingApplicant == null)
            {
                throw new KeyNotFoundException("Applicant not found");
            }

            _context.Entry(existingApplicant).CurrentValues.SetValues(applicantToUpdate);


            await _context.SaveChangesAsync();
        }

    }
}
