using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;

public class Collider
{
    public Vector2 Position { get; set; } = Vector2.Zero;
    public Vector2 Offset { get; set; } = Vector2.Zero;
    public Vector2 Size { get; set; } = Vector2.Zero;

    public float Left => Position.X + Offset.X;
    public float Right => Position.X + Offset.X + Size.X;
    public float Top => Position.Y + Offset.Y;
    public float Bottom => Position.Y + Offset.Y + Size.Y;

    private Sprite sprite;


    public Collider(Vector2 size)
    {
        Size = size;
    }
    public Collider(Vector2 size, Vector2 offset)
    {
        Size = size;
        Offset = offset;
    }
    public void Start()
    {
        sprite = new Sprite(Size);
        sprite.Color = new Color((int)Color.Blue.R, Color.Blue.G, Color.Blue.B, 50);
        sprite.Layer = 20;
        sprite.SetOffset(Offset);
    }
    public void UpdatePosition(Vector2 position)
    {
        Position = position;

        sprite.UpdatePosition(Position);
    }

    public bool IsCollidingWith(Collider other)
    {
        return Left < other.Right &&
               Right > other.Left &&
               Top < other.Bottom &&
               Bottom > other.Top;
    }

    public bool IsEmpty()
    {
        return Size.X <= 0 && Size.Y <= 0;
    }

    public void Draw()
    {
       sprite.Draw();
    }

    public static Collider Empty()
    {
        return new Collider(Vector2.Zero);
    }

    public static Collider FullTile()
    {
        return new Collider(new Vector2(BitworksGame.TILE_SIZE));
    }

}
