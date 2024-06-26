using MassTransit;
using LectureService.Domain;

namespace EventLibrary
{
    [EntityName("ClassCreated")]
    public class ClassCreated : DomainEvent
    {
        public Guid ClassId { get; set; }
        public Guid StudyProgramId { get; set; }
        public string ClassCode { get; set; }
    }
}