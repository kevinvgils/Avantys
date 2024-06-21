using MassTransit;

namespace EventLibrary
{
    [EntityName("TestCreated")]
    public class TestCreated
    {
        public Guid TestId { get; set; }
        public string Module { get; set; }

        public List<Guid>? StudentIds { get; set; }
    }
}