using Domain.Users;

namespace DomainServices
{
    public interface IApplyRepository
    {
        Applicant GetApplicant();

        Task AddApplicant(Applicant applicant);
    }
}
