namespace Domain.Events
{
    public interface IApplicantCreatedEvent
    {
        string Name { get; }
        string Email { get; }
        string StudyProgram { get; }
        Guid ApplicantId { get; }
    }
}