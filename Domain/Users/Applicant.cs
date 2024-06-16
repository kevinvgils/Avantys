using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class Applicant
    {
        public string StudentId { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Studieprogramma { get; set; }
    }
}
