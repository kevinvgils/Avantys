using EventLibrary;

namespace LectureService.Domain
{
    public class Class
    {
        public Guid ClassId { get; set; }

        private void ClassEvent(ClassCreated @event)
        {
            ClassId = @event.ClassId;
        }

        public void ClassEvent(DomainEvent @event)
        {
            switch (@event)
            {
                case ClassCreated created:
                    ClassEvent(created);
                    break;
            }
        }
    }
}
