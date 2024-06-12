using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public interface IAcceptance
    {
        string Id { get; set; }
        IStudent Student { get; set; }
    }
}
