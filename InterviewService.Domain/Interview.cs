using EventLibrary;
using InterviewService.Domain.Events;

namespace InterviewService.Domain
{
    public class Interview
    {
        public Guid InterviewId { get; set; }
        public Guid ApplicantId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }

        private void ApplyEvent(ApplicantCreated @event)
        {
            InterviewId = Guid.NewGuid();
            ApplicantId = @event.ApplicantId;
            ScheduledDate = GenerateRandomDate();
            Status = "Scheduled";
            Comments = string.Empty;
        }

        private DateTime GenerateRandomDate()
        {
            Random random = new Random();
            int daysUntilScheduled = random.Next(0, 7); // generates a number between 0 and 6
            return DateTime.Now.AddDays(daysUntilScheduled);
        }

        public void ApplyEvent(DomainEvent @event)
        {
            switch (@event)
            {
                case ApplicantCreated created:
                    ApplyEvent(created);
                    break;
            }
        }
    }
}
