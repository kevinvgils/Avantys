using MassTransit;

namespace StudentService.Domain.Events
{
    [EntityName("applicant-created")]
    public class ApplicantCreated
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string StudyProgram { get; set; }
        Guid ApplicantId { get; }
    }
}