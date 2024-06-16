namespace Domain.Events
{
    public interface IApplicantCreatedEvent
    {
        string StudentId { get; }
        string Naam { get; }
        string Email { get; }
        string Studieprogramma { get; }
    }
}