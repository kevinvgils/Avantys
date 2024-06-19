namespace LectureService.Domain
{
    public class Lecture
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid StudyMaterialId { get; set; }
        public Guid ClassId { get; set; }
        public Guid TeacherId { get; set; }

        public Lecture(Guid id, string location, DateTime startTime, DateTime endTime, Guid studyMaterialId, Guid classId, Guid teacherId)
        {
            Id = id;
            Location = location;
            StartTime = startTime;
            EndTime = endTime;
            StudyMaterialId = studyMaterialId;
            ClassId = classId;
            TeacherId = teacherId;
        }
    }
}
