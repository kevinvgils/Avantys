namespace ClassService.Domain
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid? ClassId { get; set; }
        public Class @Class { get; set; }
        public Guid? StudyProgramId { get; set; }
        public StudyProgram StudyProgram { get; set; }


        public Student(string name, string email)
        {
            Name = name;
            Email = email;
            StudentId = Guid.NewGuid();
        }
    }
}