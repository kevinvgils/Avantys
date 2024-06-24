using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassService.Domain.Events
{
    public interface IApplicantEvent
    {
        public Guid ApplicantId { get; set; }
    }
    
}
