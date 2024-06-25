using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLibrary
{
    [EntityName("TestDeleted")]
    public class TestDeleted
    {
        public Guid Id { get; set; }

        public TestDeleted() { }

        public TestDeleted(Guid id)
        {
            Id = id;
        }
    }
}
