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
        public Task Consume(ConsumeContext<ClassCreated> context)
        {
            var @event = context.Message;
            var newClass = new Class();

            newClass.ClassEvent(@event);

            _lectureRepository.AddClass(newClass);

            return Task.CompletedTask;
        }
    }
}