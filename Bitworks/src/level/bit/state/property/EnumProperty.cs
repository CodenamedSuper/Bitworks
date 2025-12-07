using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;


using System;
using System.Collections.Generic;
using System.Linq;

public class EnumProperty<T> : Property where T : Enum
{
    public IReadOnlyCollection<T> Values { get; }
    private readonly Dictionary<string, T> _nameToValue;

    private EnumProperty(string name, IEnumerable<T> allowedValues)
        : base(name)
    {
        Values = allowedValues.ToList().AsReadOnly();

        _nameToValue = Values.ToDictionary(
            value => value.ToString().ToLowerInvariant(),
            value => value
        );
    }

    public bool TryGetValue(string name, out T value)
    {
        return _nameToValue.TryGetValue(name.ToLowerInvariant(), out value);
    }

    public static EnumProperty<T> Create(string name)
    {
        return new EnumProperty<T>(name, Enum.GetValues(typeof(T)).Cast<T>());
    }

    public static EnumProperty<T> Create(string name, Func<T, bool> filter)
    {
        return new EnumProperty<T>(name, Enum.GetValues(typeof(T)).Cast<T>().Where(filter));
    }

    public override string ToString()
    {
        return $"{Name}: [{string.Join(", ", Values)}]";
    }
}