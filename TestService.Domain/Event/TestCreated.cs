using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventlibrary
{
    [EntityName("TestCreated")]
    public class TestCreated
    {
        public Guid TestId { get; set; }
        public string Module {  get; set; }
    }
}
