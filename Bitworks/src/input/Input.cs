using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworksEngine;

public class Input
{
    public static BitMouse Mouse { get; private set; }
    public static BitKeyboard Keyboard { get; private set; }

    public static void Initialize()
    {
        Keyboard = new BitKeyboard();
        Mouse = new BitMouse();
    }

    public static void Update()
    {
        Keyboard.Update();
        Mouse.Update();
    }
}
