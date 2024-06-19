namespace LectureService.Models
{
    public interface ILecture
    {
        string Location { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
    }
}
