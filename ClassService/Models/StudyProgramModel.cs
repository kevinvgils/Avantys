namespace ClassService.Models
{
    public class StudyProgramModel
    {
        public string Name { get; set; }
        public IEnumerable<string> Subjects { get; set; }
    }
}