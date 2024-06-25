using ClassService.Domain.Events;
using EventLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassService.Domain
{
    public class StudyProgram
    {
        public Guid StudyProgramId { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Subjects { get; set; }
        public IEnumerable<Class> Classes { get; set; }


        private void ApplyEvent(StudyProgramCreated @event)
        {
            StudyProgramId = @event.StudyProgramId;
            Name = @event.Name;
            Subjects = @event.Subjects;
        }

        public void ApplyEvent(DomainEvent @event)
        {
            switch (@event)
            {
                case StudyProgramCreated created:
                    ApplyEvent(created);
                    break;
            }
        }
    }
}
