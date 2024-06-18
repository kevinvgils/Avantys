using DomainServices;
using MassTransit;
using StudentService.Domain;
using EventLibrary;

namespace StudentService.Consumers
{
    public class ApplicantCreatedConsumer : IConsumer<ApplicantCreated>
    {
        private readonly IStudentRepository _studentRepository;

        public ApplicantCreatedConsumer(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public Task Consume(ConsumeContext<ApplicantCreated> context)
        {

            Student student = new Student(context.Message.Name, context.Message.ApplicantId, context.Message.StudyProgram, context.Message.Name);
            _studentRepository.AddStudent(student);
            Console.WriteLine("CONSUME");

            return Task.CompletedTask;
        }
    }
}