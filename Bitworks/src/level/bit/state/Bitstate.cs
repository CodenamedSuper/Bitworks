using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;

public class Bitstate
{
    public string Name { get; set; } = string.Empty;
    public List<BitstateCondition> Conditions { get; set; } = new List<BitstateCondition>();

    public Sprite Sprite { get; set; }

    public Bitstate(string name)
    {
        Name = name;
    }

    public void Start()
    {
    }

    public void AddCondition(BitstateCondition condition)
    {
        if (condition.Property is IntProperty intProperty && condition.Value is int)
        {
            Conditions.Add(condition);
        }
        else if (condition.Property is BooleanProperty booleanProperty && condition.Value is bool)
        {
            Conditions.Add(condition);
        }
        else if (condition.Property.GetType().GetGenericTypeDefinition() == typeof(EnumProperty<>) && condition.Value is Enum)
        {
            Conditions.Add(condition);
        }
    }

    public static Bitstate Add(Bitstate state, List<BitstateCondition> addition)
    {
        foreach (BitstateCondition addCondition in addition)
        {
            for (int i = 0; i < state.Conditions.Count; i++)
            {
                if (state.Conditions[i].Property.Name == addCondition.Property.Name)
                {
                    BitstateCondition updatedCondition = state.Conditions[i];
                    updatedCondition.Value = addCondition.Value;
                    state.Conditions[i] = updatedCondition;
                }
            }
        }

        return state;
    }

    public object GetValue(Property property)
    {
        foreach (BitstateCondition condition in Conditions)
        {
            if (condition.Property.Name == property.Name) return condition.Value;
        }

        Debug.WriteLine("Can't get value from property " + property.Name + " as it doesn't exist in the bit!");
        return null;
    }

    public bool IsEmpty()
    {
        return Conditions.Count == 0;
    }


}
