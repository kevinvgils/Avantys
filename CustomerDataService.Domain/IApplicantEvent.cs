﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyService.Domain
{
    public interface IApplicantEvent
    {
        public Guid ApplicantId { get; set; }
    }
    
}
