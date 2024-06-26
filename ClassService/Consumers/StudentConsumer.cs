using MassTransit;
using EventLibrary;
using ClassService.Domain;
using ClassService.DomainServices.Interfaces;

namespace ClassService.Consumers
{
    public class StudentConsumer : IConsumer<StudentCreated>, IConsumer<ApplicantUpdated>
    {
        private readonly IStudentRepository _studentRepository;

        public StudentConsumer(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task Consume(ConsumeContext<StudentCreated> context)
        {
            var @event = context.Message;
            var student = new Student();

            student.ApplyEvent(@event);

            await _studentRepository.UpdateStudent(student);

        }

        public async Task Consume(ConsumeContext<ApplicantUpdated> context)
        {
            try
            {
                var @event = context.Message;
                if (!@event.IsAccepted) ;

                var student = new Student();
                student.ApplyEvent(@event);
                Console.WriteLine("CREATESTUDENT APPLICANT");
                Console.WriteLine(student.StudentId);
                await _studentRepository.AddStudent(student);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }
    }
}