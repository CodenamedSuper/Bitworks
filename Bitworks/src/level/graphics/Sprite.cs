using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;

public class Sprite
{
    public string Path { get; set; } = string.Empty;
    public Texture2D Texture { get; set; }
    public Vector2 Position { get; set; } = Vector2.Zero;
    public Vector2 Offset { get; protected set; } = Vector2.Zero;
    public Vector2 Coordinates { get; set; } = Vector2.Zero;
    public Vector2 Origin { get; set; } = Vector2.Zero;
    public Vector2 Size { get; set; } = Vector2.One;
    public Vector2 Scale { get; set; } = Vector2.One;
    public Color Color { get; set; } = Color.White;
    public float Layer { get; set; } = 0;
    public bool FlippedH { get; set; } = false;

    public Sprite(string path)
    {
        Path = path;
        Texture = BitworksGame.Content.Load<Texture2D>("assets/sprites/" + Path);

        Size = new Vector2(Texture.Width, Texture.Height);
        Origin = Size / 2;

        Offset = Origin;
    }

    public Sprite(Vector2 size)
    {
        Size = size;
        Origin = Size / 2;

        Offset = Origin;
    }

    public void UpdatePosition(Vector2 position)
    {
        Position = position;
    }

    public void SetOffset(Vector2 offset)
    {
        Offset = Origin + offset;
    }

    public void ChangePath(string path)
    {
        Path = path;
        Texture = BitworksGame.Content.Load<Texture2D>("assets/sprites/" + Path);

        Size = new Vector2(Texture.Width, Texture.Height);
        Origin = Size / 2;

        Offset = Origin;
    }

    public SpriteEffects GetFlippedH()
    {
        if (FlippedH)
            return SpriteEffects.FlipHorizontally;
        return SpriteEffects.None;
    }

    public virtual void Animate()
    {

    }

    public virtual void Draw()
    {
        Texture2D texture = Texture;
        if (texture == null) texture = BitworksGame.Pixel;

        BitworksGame.SpriteBatch.Draw(texture,Position + Offset,new Rectangle((int)Coordinates.X, (int)Coordinates.Y, (int)Size.X, (int)Size.Y), Color, 0f, Origin, Scale, GetFlippedH(), (Layer) * 0.001f);
    }
}
