using MassTransit;
using StudentService.Domain.Events;

namespace EventLibrary
{
    [EntityName("StudentCreated")]
    public class StudentCreated : DomainEvent
    {
        public Guid StudentId { get; set; }
        public string StudyProgram { get; set; }
    }
}