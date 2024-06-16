﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Testing
{
    public class Points
    {
        string Id { get; set; }
        int Value { get; set; }

        public Points(string id, int value)
        {
            Id = id;
            Value = value;
        }
    }
}