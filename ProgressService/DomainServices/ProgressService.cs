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
            IEnumerable<Test> tests = testRepo.GetAllTests(studentProgram.Subjects);
            Console.WriteLine($"Recieved {tests.Count()} students for ProgressCreation");

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
            IEnumerable<Student> students = studentRepo.GetAllStudents(test.Module);

            Console.WriteLine($"Recieved {students.Count()} students for ProgressCreation");

            List<Progress> createdProgress = new List<Progress>();

            foreach (Student student in students)
            {

                Console.WriteLine($"Progress: student {student.Id}, test {test.Id}");
                Progress progress = new Progress(test.Id, student.Id, test.Module, null, null);
                createdProgress.Add(await repo.createProgress(progress));
            }

            return createdProgress;
        }

        public async Task<IEnumerable<Progress>> DeleteProgressAsync(Test test)
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
