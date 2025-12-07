using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;

public class AnimatedSprite : Sprite
{
    public Dictionary<string, Animation> Animations { get; set; } = new Dictionary<string, Animation>();
    public Animation Animation { get; set; }
    public int Frame { get; set; } = 0;
    private float counter = 0;

    public AnimatedSprite(string path) : base(path)
    {
        Offset = Origin;
    }

    public void AddAnimation(Animation animation)
    {
        Animations.Add(animation.Name, animation);

        if (Animations.Count == 1) SetAnimation(animation.Name);
    }

    public void SetAnimation(string name)
    {
        bool different = name != Animation?.Name ? true : false;

        Animation = Animations[name];

        if (different) ResetFrames();

        Size = Animation.FrameSize;

        Origin = Size / 2;

        Offset = Origin;
    }

    public void ResetFrames()
    {
        Frame = 0;
        counter = 0;
    }

    public override void Animate()
    {
        counter += Animation.Speed / 10;

        if (counter >= 1)
        {
            Frame++;

            if (Frame >= Animation.Length)
                Frame = 0;

            counter = 0;
        }
    }

    public override void Draw()
    {
        BitworksGame.SpriteBatch.Draw(Texture,Position + Offset,new Rectangle((int)Animation.Start.X,(int)Animation.Start.Y + (int)Animation.FrameSize.Y * Frame,(int)Animation.FrameSize.X,(int)Animation.FrameSize.Y),Color, 0,Origin, Scale,GetFlippedH(),(Layer) * 0.001f);
    }
}

