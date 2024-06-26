using MassTransit;
using EventLibrary;
using LectureService.Domain;
using LectureService.DomainServices.Interfaces;

namespace LectureService.Consumers
{
    public class ClassConsumer : IConsumer<ClassCreated>
    {
        private readonly ILectureRepository _lectureRepository;

        public ClassConsumer(ILectureRepository lectureRepository)
        {
            _lectureRepository = lectureRepository;
        }
        public async Task Consume(ConsumeContext<ClassCreated> context)
        {
            var @event = context.Message;
            var newClass = new Class();
            Console.WriteLine("LOGGINGGGG");
            Console.WriteLine(@event);
            newClass.ClassEvent(@event);

            await  _lectureRepository.AddClass(newClass);
        }
    }
}