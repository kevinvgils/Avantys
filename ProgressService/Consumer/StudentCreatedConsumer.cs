using EventLibrary;
using MassTransit;
using ProgressService.DomainServices.Interfaces;

namespace ProgressService.Consumer
{
    public class StudentCreatedConsumer : IConsumer<StudentCreated>
    {
        private readonly IStudentRepository _StudentRepository;
        private readonly IProgressService _progressService;

        public StudentCreatedConsumer(IProgressService progressService, IStudentRepository StudentRepository)
        {
            _progressService = progressService;
            _StudentRepository = StudentRepository;
        }

        public Task Consume(ConsumeContext<StudentCreated> context)
        {
            StudentCreated Student = new StudentCreated();

            _StudentRepository.CreateStudent(Student);
            _progressService.CreateProgressAsync(new Domain.Student(Student.StudentId, Student.StudyProgramId));

            Console.WriteLine("CONSUME Student");

            return Task.CompletedTask;
        }
    }
}
