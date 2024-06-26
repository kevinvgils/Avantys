namespace LectureService.Domain
{
    public class EventStore
    {
        public Guid Id { get; set; }
        public string AggregateId { get; set; }
        public string AggregateType { get; set; }
        public string EventType { get; set; }
        public string Data { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
