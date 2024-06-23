using ApplyService.Domain;
using MassTransit;

namespace EventLibrary
{
    [EntityName("InterviewUpdated")]
    public class InterviewUpdated : DomainEvent, IApplicantEvent
    {
        public Guid ApplicantId { get; set; }
        public Guid InterviewId { get; set; }
        public bool IsAccepted { get; set; }
    }
}