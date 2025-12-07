using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;

public class BitMap
{
    public Dictionary<Coords, Bit> Bits { get; set; } = new Dictionary<Coords, Bit>();

    public void Add(Coords coords, Bit bit)
    {
        if (Bits.ContainsKey(coords)) return;

        bit.Coords = coords;
        Bits.Add(coords, bit);
        bit.Start();

    }

    public void Remove(Coords coords)
    {
        if (Bits.ContainsKey(coords))
        {
            Bit bit = Bits[coords];
            Bits.Remove(coords);
            bit.OnRemove();

        }
    }

    public void Update()
    {
        Bits.ToList().ForEach(bit => bit.Value.Update());

    }

    public void Draw()
    {
        Bits.ToList().ForEach(bit => bit.Value.Draw());
    }
}
