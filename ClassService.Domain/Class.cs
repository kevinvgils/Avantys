using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassService.Domain
{
    public class Class
    {
        public Guid ClassId { get; set; }
        public string ClassCode { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public Guid StudyProgramId { get; set; }
        public StudyProgram StudyProgram { get; set; }
    }
}
