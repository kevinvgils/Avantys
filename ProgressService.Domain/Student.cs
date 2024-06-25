using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressService.Domain
{
    public class Student
    {
        public Guid Id { get; set; }
        public Guid ProgramId { get; set; }
        
        public Student(Guid id, Guid programId)
        {
            Id = id;
            ProgramId = programId;
        }
    }
}
