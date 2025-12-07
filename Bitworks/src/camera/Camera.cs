using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;
public class Camera
{
    public float Zoom { get; set; } = 1.0f;
    public float UIScale { get; set; } = 1.0f;
    public Vector2 Position { get; private set; } = Vector2.Zero;
    public Viewport Viewport { get; private set; }
    public Matrix Matrix { get; private set; } = Matrix.Identity;

    public Camera()
    {
        Viewport = new Viewport(0, 0, BitworksGame.Graphics.PreferredBackBufferWidth, BitworksGame.Graphics.PreferredBackBufferHeight);
    }

    public void Update()
    {
        Matrix = Matrix.CreateTranslation(-Position.X, -Position.Y, 0) *
            Matrix.CreateScale(Zoom) *
            Matrix.CreateTranslation(Viewport.Width / 2, Viewport.Height / 2, 0);
    }

    public void Translate(Vector2 translation)
    {
        Position += translation;

        // TODO later: move uis with camera
    }

    public Vector2 GetScreenPostion()
    {
        return new Vector2(Matrix.Translation.X, Matrix.Translation.Y);
    }

}

