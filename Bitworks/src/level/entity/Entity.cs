using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;

public abstract class Entity
{
    public string ID { get; set; } = string.Empty;
    public Vector2 Position { get; set; } = Vector2.Zero;
    public AnimatedSprite Sprite { get; set; }
    public bool OnGround { get; set; } = true;
    public bool Gravitational { get; set; } = true;
    public Vector2 Velocity { get; set; } = Vector2.Zero;
    public Direction Direction { get; set; } = Direction.Right;
    public Collider Collider { get; set; }
    public List<Capability> Capabilities { get; set; } = new List<Capability>();

    private bool wasOnGround = false;
    private Vector2 previousVelocity = Vector2.Zero;

    public Entity(string id)
    {
        ID = id;
    }

    public virtual void Start()
    {
        Collider.Start();


    }

    public void AddCapability(Capability capability)
    {
        Capabilities.Add(capability);
        capability.Owner = this;
        capability.Start();
    }

    public T GetCapability<T>() where T : Capability
    {
        return Capabilities.FirstOrDefault(cap => cap is T) as T;
    }

    public void RemoveCapability(Capability capability)
    {
        Capabilities.Remove(capability);
    }

    public virtual void Update()
    {
        Capabilities.ForEach(cap => cap.Update());

        if (Gravitational && !OnGround) ApplyGravity();

        UpdatePhysics();

        CheckDirection();
        Sprite.UpdatePosition(Position);

    }
    private void UpdatePhysics()
    {
        OnGround = false;
        Vector2 newPos = Position + (Velocity * (float)BitworksGame.DeltaTime);
        Collider.UpdatePosition(newPos);

        foreach (Bit bit in BitworksGame.GameManager.Level.BitMap.Bits.Values)
        {
            Collider bitCollider = bit.Collider;
            if (bitCollider.IsEmpty()) continue;

            if (newPos.X != Position.X)
            {
                Collider.UpdatePosition(new Vector2(newPos.X, Position.Y));
                if (Collider.IsCollidingWith(bitCollider))
                {
                    if (newPos.X > Position.X) newPos.X = bitCollider.Left - Collider.Size.X - Collider.Offset.X;
                    else newPos.X = bitCollider.Right - Collider.Offset.X;
                    continue;
                }
            }

            Collider.UpdatePosition(new Vector2(Position.X, newPos.Y));
            if (Collider.IsCollidingWith(bitCollider))
            {
                if (Velocity.Y > 0)
                {
                    newPos.Y = bitCollider.Top - Collider.Size.Y - Collider.Offset.Y;

                    OnGround = true;
                    Velocity = new Vector2(Velocity.X, 0);

                    if (!wasOnGround && previousVelocity.Y >= 1)
                    {
                        bit.OnEntityLand(this);
                        OnLanded();
                    }


                }
                else
                {
                    newPos.Y = bitCollider.Bottom - Collider.Offset.Y;
                    Velocity = new Vector2(Velocity.X, 0);
                }
            }

        }

        Position = newPos;


        wasOnGround = OnGround;
        previousVelocity = Velocity;

    }
    public void ApplyGravity()
    {
        Velocity = new Vector2(Velocity.X, Velocity.Y + BitworksGame.GRAVITY * (float)BitworksGame.DeltaTime);

        if (Velocity.Y > 250) Velocity = new Vector2(Velocity.X, 250);
    }

    public virtual void OnLanded()
    {
    }

    public bool IsFacingRight()
    {
        if (Direction == Direction.Right)
        {
            return true;
        }

        return false;
    }
    public void CheckDirection()
    {
        if (Velocity.X > 0) Direction = Direction.Right;
        else if (Velocity.X < 0) Direction = Direction.Left;

        Sprite.FlippedH = !IsFacingRight();
    }
    public virtual void Animate()
    {
        Capabilities.ForEach(cap => cap.Animate());

        Sprite.Animate();
    }
    public virtual void Draw()
    {
        Capabilities.ForEach(cap => cap.Draw());

        Sprite.Draw();

        if (BitworksGame.SHOW_COLLIDERS) Collider.Draw();
    }
}
