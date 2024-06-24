using MassTransit;
using ClassService.Domain.Events;

namespace EventLibrary
{
    [EntityName("StudentCreated")]
    public class StudentCreated : DomainEvent
    {
        public Guid StudentId { get; set; }
        public Guid ClassId { get; set; }
        public Guid StudyProgramId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}