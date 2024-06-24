using ApplyService.Domain;

namespace ApplyService.DomainServices.Interfaces
{
    public interface IApplyRepository
    {
        Task AddApplicant(Applicant applicant);

        Task<Applicant> GetApplicantById(Guid applicantId);
        Task UpdateApplicant(Applicant applicantToUpdate);
        Task<List<Applicant>> GetAllApplicantsAsync();

    }
}
