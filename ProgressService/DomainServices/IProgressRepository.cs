using System;
using ProgressService.Domain;

namespace DomainServices
{
    public interface IProgressRepository
    {
        IEnumerable<Progress> getAllProgress();
        Progress getProgress(Guid id);

        Task createProgress(Progress progress);

        Task createMultipleProgress(Progress progress, List<Guid>? Students);

        Task gradeProgress(Progress progress);
    }
}
