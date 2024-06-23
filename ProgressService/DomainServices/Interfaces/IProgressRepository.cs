using System;
using ProgressService.Domain;

namespace ProgressService.DomainServices.Interfaces
{
    public interface IProgressRepository
    {
        IEnumerable<Progress> getAllProgress();
        Progress getProgress(Guid id);

        Task<Progress> createProgress(Progress progress);

        Task gradeProgress(Progress progress);
    }
}
