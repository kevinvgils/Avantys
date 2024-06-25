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
        public IEnumerable<string> Subjects { get; set; }

        public StudyProgram()
        {

        }

        public StudyProgram(Guid studyProgramId, string name, IEnumerable<string> subjects)
        {
            Id = studyProgramId;
            Name = name;
            Subjects = subjects;
        }
    }
}
