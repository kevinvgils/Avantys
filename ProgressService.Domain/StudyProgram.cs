using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressService.Domain
{
    public class StudyProgram
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Subjects { get; set; }  // Use List for better EF Core compatibility

        public StudyProgram()
        {
            Subjects = new List<string>();
        }

        public StudyProgram(Guid studyProgramId, string name, IEnumerable<string> subjects)
        {
            Id = studyProgramId;
            Name = name;
            Subjects = subjects.ToList();  // Ensure Subjects is a list
        }
    }
}
