using MassTransit;
using EventLibrary;
using StudentService.Domain;
using StudentService.DomainServices.Interfaces;

namespace StudentService.Consumers
{
    public class ApplicantUpdatedConsumer : IConsumer<ApplicantUpdated>
    {
        private readonly IStudentRepository _studentRepository;

        public ApplicantUpdatedConsumer(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public Task Consume(ConsumeContext<ApplicantUpdated> context)
        {
            var @event = context.Message;
            if (!@event.IsAccepted) return Task.CompletedTask;

            var student = new Student(@event.Name, @event.ApplicantId, @event.StudyProgram, @event.Email);

            _studentRepository.AddStudent(student);

            return Task.CompletedTask;
        }
    }
}