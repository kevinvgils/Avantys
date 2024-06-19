namespace LectureService.Domain
{
    public class StudyMaterial
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public StudyMaterial(Guid id, string content)
        {
            Id = id;
            Content = content;
        }
    }
}
