using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;

public abstract class Property
{
    public string Name { get; set; } = string.Empty;

    public Property(string name)
    {
        Name = name;
    }
}
