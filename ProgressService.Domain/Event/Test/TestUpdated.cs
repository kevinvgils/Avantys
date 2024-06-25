using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLibrary
{
    [EntityName("TestUpdated")]
    public class TestUpdated
    {
        public Guid Id { get; set; }
        public string Module { get; set; }

        public TestUpdated() { }

        public TestUpdated(Guid id, string module)
        {
            Id = id;
            Module = module;
        }
    }
}
