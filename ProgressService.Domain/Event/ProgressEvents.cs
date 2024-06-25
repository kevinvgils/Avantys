using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLibrary
{
    [EntityName("StudentCreated")]
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

    [EntityName("StudyProgramCreated")]
    public class StudyProgram
    {
        public Guid StudyProgramId { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Subjects { get; set; }
    }
}
