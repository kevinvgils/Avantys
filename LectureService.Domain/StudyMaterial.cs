using EventLibrary;

namespace LectureService.Domain
{
    public class StudyMaterial
    {
        public Guid StudyMaterialId { get; set; }
        public string Content { get; set; }

        private void StudyMaterialEvent(StudyMaterialCreated @event)
        {
            StudyMaterialId = @event.StudyMaterialId;
            Content = @event.Content;
        }

        public void StudyMaterialEvent(DomainEvent @event)
        {
            switch (@event)
            {
                case StudyMaterialCreated created:
                    StudyMaterialEvent(created);
                    break;
            }
        }
    }
}
