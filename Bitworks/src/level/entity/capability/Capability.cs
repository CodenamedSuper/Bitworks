using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;   

public abstract class Capability
{
    public Entity Owner { get; set; }
    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void Animate() { }
    public virtual void Draw() { }

}
