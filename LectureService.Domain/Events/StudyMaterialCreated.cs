using LectureService.Domain;
using MassTransit;

namespace EventLibrary
{
    [EntityName("StudyMaterialCreated")]
    public class StudyMaterialCreated : DomainEvent, IStudyMaterialEvent
    {
        public string Content { get; set; }
        public Guid StudyMaterialId { get; set; }
    }
}