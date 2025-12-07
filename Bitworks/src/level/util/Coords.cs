using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;

public record struct Coords
{
    public Vector2 Value;
    public Coords(Vector2 value)
    {
        Value = value;
    }
    public Coords(int x, int y)
    {
        Value = new Vector2(x, y);
    }
    public Coords(int size)
    {
        Value = new Vector2(size);
    }
    public Coords Up() => new Coords(Value + new Vector2(0, -1));
    public Coords Down() => new Coords(Value + new Vector2(0, 1));
    public Coords Left() => new Coords(Value + new Vector2(-1, 0));
    public Coords Right() => new Coords(Value + new Vector2(1, 0));
    public Vector2 ToPosition()
    {
        return Value * BitworksGame.TILE_SIZE;
    }
    public static Vector2 ToPosition(Coords coords)
    {
        return coords.Value * BitworksGame.TILE_SIZE;
    }
    public static Coords FromPosition(Vector2 pos)
    {
        int x = (int)Math.Floor((double)pos.X / BitworksGame.TILE_SIZE);
        int y = (int)Math.Floor((double)pos.Y / BitworksGame.TILE_SIZE);
        return new Coords(x, y);
    }
    public static Coords Center()
    {
        return new Coords(0, 0);
    }
    public override string ToString()
    {
        return Value.ToString();
    }
}