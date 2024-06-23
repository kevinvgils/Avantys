namespace ProgramService.Domain
{
    public class Program
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Modules { get; set; }

        public Program() => Id = Guid.NewGuid();
        public Program(string name) : this() => Name = name;    
    }
}
