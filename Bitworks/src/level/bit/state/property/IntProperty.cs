using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;   

public class IntProperty : Property
{
    public int Min { get; set; }
    public int Max { get; set; }

    private IntProperty(string name, int min, int max) : base(name)
    {
        Min = min;
        Max = max;
    }

    public static IntProperty Create(string name, int min, int max)
    {
        return new IntProperty(name, min, max);
    }
}
