using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressService.Domain
{
    public class StudyProgram
    { 
        public Guid StudyProgramId { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Subjects { get; set; }
    }
}
