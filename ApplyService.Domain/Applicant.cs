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
    }
}
