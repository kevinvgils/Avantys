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
            Console.WriteLine("CONSUME");

            return Task.CompletedTask;
        }
    }
}