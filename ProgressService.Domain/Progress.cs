using Eventlibrary;

namespace ProgressService.Domain
{
    public class Progress
    {
        public Guid Id { get; set; }
        public Guid TestId { get; set; }
        public Guid StudentId { get; set; }

        public string Module { get; set; }

        public float? Grade { get; set; }
        public int? StudyPoints { get; set; }

        public Progress()
        {
            Id = Guid.NewGuid();
        }

        public Progress(Guid testId, Guid studentId, string module, float? grade, int? studyPoints) : this()
        {
            TestId = testId;
            StudentId = studentId;
            Module = module;
            Grade = grade;
            StudyPoints = studyPoints;
        }
        public Progress(TestCreated test, Student student) : this()
        {
            TestId = test.Id;
            StudentId = student.Id;
            Module = test.Module;
            Grade = null;
            StudyPoints = null;
        }
    }
}
