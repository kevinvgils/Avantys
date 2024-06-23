namespace ProgramService.Domain
{
    public class StudyProgram
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Modules { get; set; }

        public StudyProgram() => Id = Guid.NewGuid();
        public StudyProgram(string name) : this() => Name = name;    
    }
}
