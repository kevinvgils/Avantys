using System;
using ProgressService.Domain;

namespace DomainServices
{
    public interface IProgressRepository
    {
        IEnumerable<Progress> getAllProgress();

        Task createProgress(Progress progress);

        Task gradeProgress(Progress progress);
    }
}
