using ClassService.Domain.Events;
using EventLibrary;
using System.Xml.Linq;

namespace ClassService.Domain
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid? ClassId { get; set; }
        public Class? @Class { get; set; }
        public Guid? StudyProgramId { get; set; }
        public StudyProgram? StudyProgram { get; set; }

        private void ApplyEvent(StudentCreated @event)
        {
            StudyProgramId = @event.StudyProgramId;
            ClassId = @event.ClassId;
            Name = @event.Name;
            Email = @event.Email;
            StudentId = @event.StudentId;
        }

        private void ApplyEvent(ApplicantUpdated @event)
        {
            Name = @event.Name;
            Email = @event.Email;
            StudentId = Guid.NewGuid();
            ClassId = null;
            StudyProgramId = null;
        }

        public void ApplyEvent(DomainEvent @event)
        {
            switch (@event)
            {
                case StudentCreated created:
                    ApplyEvent(created);
                    break;
                case ApplicantUpdated applicantUpdated:
                    ApplyEvent(applicantUpdated);
                    break;
            }
        }
    }
}