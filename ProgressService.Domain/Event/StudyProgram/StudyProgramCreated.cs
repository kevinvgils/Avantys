using MassTransit;

namespace EventLibrary
{
    [EntityName("StudyProgramCreated")]
    public class StudyProgramCreated
    {
        public Guid StudyProgramId { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Subjects { get; set; }
    }
}