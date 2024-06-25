using Eventlibrary;
using MassTransit;
using ProgressService.DomainServices.Interfaces;

namespace ProgressService.Consumer
{
    public class StudentCreatedConsumer : IConsumer<Student>
    {
        private readonly IStudentRepository _StudentRepository;
        private readonly IProgressService _progressService;

        public StudentCreatedConsumer(IProgressService progressService, IStudentRepository StudentRepository)
        {
            _progressService = progressService;
            _StudentRepository = StudentRepository;
        }

        public Task Consume(ConsumeContext<Student> context)
        {
            Student Student = new Student(context.Message.Id, context.Message.ProgramId);
            _StudentRepository.CreateStudent(Student);
            _progressService.CreateProgressAsync(Student);

            Console.WriteLine("CONSUME Student");

            return Task.CompletedTask;
        }
    }
}
