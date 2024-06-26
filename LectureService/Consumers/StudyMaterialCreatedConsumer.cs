using LectureService.Domain;
using LectureService.DomainServices.Interfaces;
using EventLibrary;
using MassTransit;
using LectureService.Infrastructure;

namespace LectureService.Consumers
{
    public class StudyMaterialCreatedConsumer : IConsumer<StudyMaterialCreated>
    {
        private readonly IStudyMaterialRepository _studyMaterialRepository;

        public StudyMaterialCreatedConsumer(IStudyMaterialRepository studyMaterialRepository)
        {
            _studyMaterialRepository = studyMaterialRepository;
        }

        public async Task Consume(ConsumeContext<StudyMaterialCreated> context)
        {
            var @event = context.Message;
            var studyMaterial = new StudyMaterial();
            studyMaterial.StudyMaterialEvent(@event);
            await _studyMaterialRepository.CreateStudyMaterial(studyMaterial);
        }
    }
}
