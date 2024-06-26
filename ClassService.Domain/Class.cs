using ClassService.Domain.Events;
using EventLibrary;
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
        public IEnumerable<Student>? Students { get; set; }
        public Guid StudyProgramId { get; set; }
        public StudyProgram StudyProgram { get; set; }

        private void ApplyEvent(ClassCreated @event)
        {
            StudyProgramId = @event.StudyProgramId;
            ClassId = @event.ClassId;
            ClassCode = @event.ClassCode;
            Students = null;
        }

        public void ApplyEvent(DomainEvent @event)
        {
            switch (@event)
            {
                case ClassCreated created:
                    ApplyEvent(created);
                    break;
            }
        }
    }
}
