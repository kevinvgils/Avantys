using MassTransit;
using StudentService.Domain.Events;

namespace EventLibrary
{
    [EntityName("ApplicantUpdated")]
    public class ApplicantUpdated : DomainEvent, IApplicantEvent
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string StudyProgram { get; set; }
        public bool IsAccepted { get; set; }
        public Guid ApplicantId { get; set; }
    }
}