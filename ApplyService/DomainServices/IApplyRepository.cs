using ApplyService.Domain;

namespace ApplyService.DomainServices
{
    public interface IApplyRepository
    {
        Applicant GetApplicant();

        Task AddApplicant(Applicant applicant);
    }
}
