using MassTransit;
using ClassService.Domain.Events;

namespace EventLibrary
{
    [EntityName("StudyProgramCreated")]
    public class StudyProgramCreated : DomainEvent
    {
        public Guid StudyProgramId { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Subjects { get; set; }
    }
}