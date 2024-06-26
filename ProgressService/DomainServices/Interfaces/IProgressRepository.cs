using System;
using ProgressService.Domain;

namespace ProgressService.DomainServices.Interfaces
{
    public interface IProgressRepository
    {
        IEnumerable<Progress> getAllProgress();

        Progress getProgress(Guid id);
        IEnumerable<Progress> findAllProgressFromStudent(Guid studentId);

        Task<Progress> createProgress(Progress progress);

        Task deleteProgress(Progress progress);

        Task gradeProgress(Progress progress);
    }
}
