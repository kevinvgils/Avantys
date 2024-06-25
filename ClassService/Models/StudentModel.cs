namespace ClassService.Models
{
    public class StudentModel
    {
        public string StudentId { get; set; }
        public string? ClassId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? StudyProgramId { get; set; }
    }
}