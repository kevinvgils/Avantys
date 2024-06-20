namespace ProgressService.Domain
{
    public class Progress
    {
        public Guid Id { get; set; }
        public Guid TestId { get; set; }
        public string Module { get; set; }

        public float Grade { get; set; }
        public int StudyPoints { get; set; }
    }
}
