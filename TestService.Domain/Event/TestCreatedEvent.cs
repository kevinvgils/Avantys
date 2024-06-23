﻿using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestService.Domain.Event
{
    [EntityName("TestCreated")]
    internal class TestCreatedEvent
    {
        public Guid TestId { get; set; }
        public string Module {  get; set; }
    }
}
