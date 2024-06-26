using MassTransit;
using ClassService.Domain.Events;

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