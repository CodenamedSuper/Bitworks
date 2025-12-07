using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;

public class BitstateGroup
{
    public string Name { get; set; } = string.Empty;
    public List<Bitstate> States { get; set; } = new List<Bitstate>();

    public BitstateGroup(Func<Bit> bit)
    {
        Name = bit().ID;
    }

    public BitstateGroup AddState(string name, params BitstateCondition[] conditions) 
    {
        Bitstate bitstate = new Bitstate(name);

        foreach (BitstateCondition condition in conditions)
        {
            bitstate.AddCondition(condition);
        }

        States.Add(bitstate);

        return this;
    }

    public bool Contains(Bitstate bitstate)
    {
        return States.Contains(bitstate);
    }

    public bool IsEmpty()
    {
        return States.Count == 0;
    }

}
