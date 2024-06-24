namespace Domain.Events
{
    public class ApplicantCreated
    {
        public string Name { get; }
        public string Email { get; }
        public string StudyProgram { get; }
        public Guid ApplicantId { get; }
    }
}