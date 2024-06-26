using ApplyService.Domain;
using MassTransit;
using MassTransit.Topology;

namespace EventLibrary
{
    [EntityName("ApplicantCreated")]
    public class ApplicantCreated : DomainEvent, IApplicantEvent
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string StudyProgram { get; set; }
        public Guid ApplicantId { get; set; }
    }
}