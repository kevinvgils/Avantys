using LectureService.Domain;
using MassTransit;

namespace EventLibrary
{
    [EntityName("LectureCreated")]
    public class LectureCreated : DomainEvent, ILectureEvent
    {
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Teacher { get; set; }
        public Guid LectureId { get; set; }
    }
}