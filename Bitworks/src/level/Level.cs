using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;

public abstract class Level
{
    public BitMap BitMap { get; set; } = new BitMap();
    public List<Entity> Entities { get; set; } = new List<Entity>();

    public void Start()
    {
        Generate();
    }
    public virtual void Generate()
    {

    }
    public void PlaceBit(Coords coords, Func<Bit> bit)
    {
        BitMap.Add(coords, bit());
    }
    public Bit GetBit(Coords coords)
    {
        if(ContainsBit(coords)) return BitMap.Bits[coords];

        return null;
    }
    public bool ContainsBit(Coords coords)
    {
        return BitMap.Bits.ContainsKey(coords);
    }
    public void RemoveBit(Coords coords)
    {
        BitMap.Remove(coords);
    }

    public void SpawnEntity(Coords coords, Entity entity)
    {
        entity.Position = coords.ToPosition();
        Entities.Add(entity);
        entity.Start();
    }

    public void DespawnEntity(Entity entity)
    {
        Entities.Remove(entity);
    }

    public void Update()
    {

        Entities.ForEach(entity => entity.Update());

    }

    public void UpdateBits(Bit source)
    {
        BitMap.Update();

    }

    public void Animate()
    {
        Entities.ForEach(entity => entity.Animate());

    }

    public void Draw()
    {
        BitMap.Draw();

        Entities.ForEach(entity => entity.Draw());

    }
}
