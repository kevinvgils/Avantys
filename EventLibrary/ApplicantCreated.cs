using MassTransit;

namespace EventLibrary
{
    [EntityName("ApplicantCreated")]
    public class ApplicantCreated
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string StudyProgram { get; set; }
        public Guid ApplicantId { get; set; }
    }
}