using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLibrary
{
    [EntityName("TestCreated")]
    public class TestCreated
    {
        public Guid Id { get; set; }
        public string Module { get; set; }

        public TestCreated() { }

        public TestCreated(Guid id, string module)
        {
            Id = id;
            Module = module;
        }
    }
}
