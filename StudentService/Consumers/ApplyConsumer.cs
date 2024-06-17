using Domain.Events;
using Domain.Users;
using DomainServices;
using MassTransit;

namespace StudentService.Consumers
{
    public class ApplyConsumer : IConsumer<IApplicantCreatedEvent>
    {
        private readonly IStudentRepository _studentRepository;

        public ApplyConsumer(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public Task Consume(ConsumeContext<IApplicantCreatedEvent> context)
        {
            Console.WriteLine("CONSUME");

            Student student = new Student(context.Message.Name, context.Message.ApplicantId, context.Message.StudyProgram, context.Message.Name);
            _studentRepository.AddStudent(student);
            Console.WriteLine("CONSUME");

            return Task.CompletedTask;
        }
    }
}