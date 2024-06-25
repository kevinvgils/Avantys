using EventLibrary;
using MassTransit;
using ProgressService.Domain;
using ProgressService.DomainServices.Interfaces;
using ProgressService.Infrastructure.Migrations;
using System.Linq;

namespace ProgressService.DomainServices
{
    public class ProgressService(IProgressRepository repo, ITestRepository testRepo, IStudentRepository studentRepo, IProgramRepository studyRepo) : IProgressService
    {
        public async Task<IEnumerable<Progress>> CreateProgressAsync(Student student)
        {
            StudyProgram studentProgram = studyRepo.GetPrograms(student.ProgramId);

            IEnumerable<TestCreated> tests = testRepo.GetAllTests(studentProgram.Subjects);
            List<Progress> createdProgress = new List<Progress>();

            foreach (TestCreated test in tests)
            {
                Progress progress = new Progress(test.Id, student.Id, test.Module, null, null);
                createdProgress.Add(await repo.createProgress(progress));
            }

            return createdProgress;
        }

        public async Task<IEnumerable<Progress>> CreateProgressAsync(TestCreated test)
        {
            IEnumerable<Student> students = studentRepo.GetAllStudents(test.Module); //TODO: Filter on module
            List<Progress> createdProgress = new List<Progress>();

            foreach (Student student in students)
            {
                Progress progress = new Progress(test.Id, student.Id, test.Module, null, null);
                createdProgress.Add(await repo.createProgress(progress));
            }

            return createdProgress;
        }

        public async Task<IEnumerable<Progress>> DeleteProgressAsync(TestCreated test)
        {
            IEnumerable<Progress> ProgressesToDelete = repo.getAllProgress().Where(x => x.TestId == test.Id);

            foreach (Progress progress in ProgressesToDelete) { 
                await repo.deleteProgress(progress);
            }

            return ProgressesToDelete;
        }

        public async Task<IEnumerable<Progress>> DeleteProgressAsync(Student student)
        {
            IEnumerable<Progress> ProgressesToDelete = repo.getAllProgress().Where(x => x.StudentId == student.Id);

            foreach (Progress progress in ProgressesToDelete)
            {
                await repo.deleteProgress(progress);
            }

            return ProgressesToDelete;
        }
    }
}
