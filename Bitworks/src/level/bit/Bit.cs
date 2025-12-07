using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;

public abstract class Bit
{
    public string ID { get; set; } = string.Empty;
    public Coords Coords { get; set; } = Coords.Center();
    public Bitstate State { get; private set; }

    public Collider Collider { get; set; } = Collider.FullTile();

    public Sprite Sprite { get; set; } 

    public Bit(string id)
    {
        ID = id;
    }
    public Vector2 GetPosition()
    {
        return Coords.ToPosition();
    }

    public virtual void Start()
    {
        Collider.Start();

        Sprite.UpdatePosition(Coords.ToPosition());

        Collider.UpdatePosition(Coords.ToPosition());
    }

    public bool HasCollider()
    {
        return !Collider.IsEmpty();
    }

    public void SetState(params BitstateCondition[] conditions) 
    {

        BitstateGroup bitstateGroup = Registries.BITSTATE_GROUPS.List[ID]();

        if (State == null && conditions.Length == 0) 
        {
            State = bitstateGroup.States.First();
            SetSprite("bit/" + State.Name);
            return;

        }
        else if(State == null && conditions.Length > 0)
        {
            foreach (Bitstate bitstate in bitstateGroup.States) 
            {
                List<BitstateCondition> conditions1 = new();
                List<BitstateCondition> conditions2 = new();

                foreach (BitstateCondition condition in bitstate.Conditions) conditions1.Add(condition);
                foreach (BitstateCondition condition in conditions) conditions2.Add(condition);

                if (conditions1.All(item => conditions2.Contains(item))) 
                {
                    State = bitstate;
                    SetSprite("bit/" + State.Name);
                    return;
                }
            }
        }
        else
        {
            foreach (Bitstate bitstate in bitstateGroup.States)
            {
                List<BitstateCondition> conditions1 = new();
                List<BitstateCondition> conditions2 = new();

                foreach (BitstateCondition condition in bitstate.Conditions) conditions1.Add(condition);
                foreach (BitstateCondition condition in Bitstate.Add(State, conditions.ToList()).Conditions) conditions2.Add(condition);

                if (conditions1.All(item => conditions2.Contains(item)))
                {
                    State = bitstate;
                    SetSprite("bit/" + State.Name);
                    return;
                }
            }
        }

        Debug.WriteLine("Couldn't find bitstate for " + ID +  " with the following conditions:");

        for(int i = 0; i < conditions.Length; i++)
        {
            Debug.WriteLine(conditions[i].Property.Name + " with value: " + conditions[i].Value);
        }
    }

    public void SetSprite(string path)
    {
        if(Sprite == null)
        {
            Sprite = new Sprite(path);
        }
        else
        {
            Sprite.ChangePath(path);
        }

        Sprite.UpdatePosition(Coords.ToPosition());
    }

    public virtual void OnRemove()
    {
    }
    public virtual void OnEntityLand(Entity entity)
    {

    }
    public virtual void Update()
    {

    }
    public virtual void Animate()
    {
        Sprite.Animate();
    }
    public virtual void Draw()
    {
        Sprite.Draw();

        if(BitworksGame.SHOW_COLLIDERS) Collider.Draw();

    }
}
