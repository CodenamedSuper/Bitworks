using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;

public class Animation
{
    public string Name { get; set; } = string.Empty;
    public Vector2 Start { get; set; } = Vector2.Zero;
    public int Length { get; set; } = 1;
    public Vector2 FrameSize { get; set; } = new Vector2(BitworksGame.TILE_SIZE);
    public float Speed { get; set; } = 1;

    public Animation(string name, Vector2 start, int length, Vector2 frameSize)
    {
        Name = name;
        Start = start;
        Length = length;
        FrameSize = frameSize;
    }
    public Animation(string name, Vector2 start, int length, Vector2 frameSize, float speed)
    {
        Name = name;
        Start = start;
        Length = length;
        FrameSize = frameSize;
        Speed = speed;
    }
}
