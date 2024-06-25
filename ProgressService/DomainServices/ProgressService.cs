﻿using Eventlibrary;
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

            IEnumerable<Test> tests = testRepo.getAllTests(studentProgram.Subjects);
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
            IEnumerable<Student> students = studentRepo.getAllStudents(test.Module); //TODO: Filter on module
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