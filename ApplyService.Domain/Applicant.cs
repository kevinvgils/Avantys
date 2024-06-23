using EventLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyService.Domain
{
    public class Applicant
    {
        public Guid ApplicantId { get; set; }
        public Guid? StudentId { get; set; }
        public string Email {  get; set; }
        public DateTime ApplyDate { get; set; }
        public string Name { get; set; }
        public bool IsAccepted { get; set; }


        private void ApplyEvent(ApplicantCreated @event) 
        { 
            ApplicantId = @event.ApplicantId;
            StudentId = null;
            Email = @event.Email;
            Name = @event.Name;
            IsAccepted = false;
            ApplyDate = DateTime.UtcNow;
        }

        public void ApplyEvent(DomainEvent @event) 
        {
            switch (@event)
            {
                case ApplicantCreated created:
                    ApplyEvent(created);
                    break;
            }
        }


    }
}
