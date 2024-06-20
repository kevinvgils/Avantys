
using MassTransit;
using EventLibrary;
using TeacherService.Domain;
using DomainServices;

namespace TeacherService.Consumers
{
    public class TeacherCreatedConsumer : IConsumer<TeacherCreated>
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherCreatedConsumer(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public Task Consume(ConsumeContext<TeacherCreated> context)
        {

            Teacher teacher = new Teacher(context.Message.Name, context.Message.Email);
            _teacherRepository.AddTeacher(teacher);
            Console.WriteLine("CONSUME");

            return Task.CompletedTask;
        }


    }
}