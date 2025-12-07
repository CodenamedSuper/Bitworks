using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;

public class BooleanProperty : Property
{
    private BooleanProperty(string name) : base(name)
    {
    }

    public static BooleanProperty Create(string name)
    {
        return new BooleanProperty(name);
    }
}
