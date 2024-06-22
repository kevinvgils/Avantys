using ApplyService.Domain;

namespace ApplyService.DomainServices.Interfaces
{
    public interface IApplyService
    {
        Task<Applicant> CreateApplicantyAsync(Applicant applicant);
        Task<Applicant> UpdateApplicantAsync(Guid id, Applicant applicant);
    }
}
