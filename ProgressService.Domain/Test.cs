using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressService.Domain
{
    public class Test
    {
        public Guid Id { get; set; }
        public string Module { get; set; }

        public Test() { }

        public Test(Guid id, string module)
        {
            Id = id;
            Module = module;
        }
    }
}
