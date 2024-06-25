using EventLibrary;

namespace LectureService.Domain
{
    public class Lecture
    {
        public Guid LectureId { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid? StudyMaterialId { get; set; }
        public Guid? ClassId { get; set; }
        public string Teacher { get; set; }

        private void LectureEvent(LectureCreated @event)
        {
            LectureId = @event.LectureId;
            Location = @event.Location;
            StartTime = @event.StartTime;
            EndTime = @event.EndTime;
            StudyMaterialId = null;
            ClassId = null;
            Teacher = @event.Teacher;
        }

        public void LectureEvent(DomainEvent @event)
        {
            switch (@event)
            {
                case LectureCreated created:
                    LectureEvent(created);
                    break;
            }
        }
    }
}
