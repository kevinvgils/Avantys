using LectureService.Domain;
using LectureService.DomainServices.Interfaces;
using EventLibrary;
using MassTransit;

namespace LectureService.Consumers
{
    public class LectureCreatedConsumer : IConsumer<LectureCreated>
    {
        private readonly ILectureRepository _lectureRepository;

        public LectureCreatedConsumer(ILectureRepository lectureRepository)
        {
            _lectureRepository = lectureRepository;
        }

        public async Task Consume(ConsumeContext<LectureCreated> context)
        {
            var @event = context.Message;
            var lecture = new Lecture();
            lecture.LectureEvent(@event);
            await _lectureRepository.AddLecture(lecture);
        }
    }
}
