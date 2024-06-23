using MassTransit;
using ProgressService.Domain;
using ProgressService.DomainServices.Interfaces;
using ProgressService.Infrastructure.Migrations;
using System.Linq;
using static ProgressService.Domain.Event.ProgressEvents;

namespace ProgressService.DomainServices
{
    public class ProgressService(IProgressRepository repo) : IProgressService
    {
        public async Task<IEnumerable<Progress>> CreateProgressAsync(Student student)
        {
            IEnumerable<Test> tests = null;
            List<Progress> createdProgress = new List<Progress>();

            foreach (Test test in tests)
            {
                Progress progress = new Progress(test.Id, student.Id, test.Module, null, null);
                createdProgress.Add(await repo.createProgress(progress));
            }

            return createdProgress;
        }

        public async Task<IEnumerable<Progress>> CreateProgressAsync(Test test)
        {
            IEnumerable<Student> students = null;
            List<Progress> createdProgress = new List<Progress>();

            foreach (Student student in students)
            {
                Progress progress = new Progress(test.Id, student.Id, test.Module, null, null);
                createdProgress.Add(await repo.createProgress(progress));
            }

            return createdProgress;
        }
    }
}
