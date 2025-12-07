using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;

public class Registries
{
    public static readonly Registry<Func<Bit>> BITS = new Registry<Func<Bit>>();
    public static readonly Registry<Func<BitstateGroup>> BITSTATE_GROUPS = new Registry<Func<BitstateGroup>>();
    public static readonly Registry<Property> BITSTATE_PROPERTIES = new Registry<Property>();
    public static readonly Registry<Func<Entity>> ENTITIES = new Registry<Func<Entity>>();

}
