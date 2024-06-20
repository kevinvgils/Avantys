using System;
using ProgressService.Domain;

namespace DomainServices
{
    public interface IProgressRepository
    {
        IEnumerable<Progress> getAllProgress();
        Progress getProgress(Guid id);

        Task createProgress(Progress progress);

        Task gradeProgress(Progress progress);
    }
}
