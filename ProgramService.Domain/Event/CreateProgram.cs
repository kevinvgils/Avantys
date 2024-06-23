using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLibrary
{
    [EntityName("ProgramCreated")]
    public class CreateProgram
    {
        public Guid Id { get; set; }
        public IEnumerable<string> Modules { get; set; }
    }
}
