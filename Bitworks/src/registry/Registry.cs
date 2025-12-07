using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;

public class Registry<T>
{
    public Dictionary<string, T> List { get; private set; } = new Dictionary<string, T>();

    public void Register(string id, T value)
    {
        List.Add(id, value);
    }

}
