using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace BitworksEngine;
public class BitKeyboard
{
    private KeyboardState newKeyboard, oldKeyboard;
    private List<BitKey> pressedKeys = new List<BitKey>(), previousPressedKeys = new List<BitKey>();

    public void Update()
    {
        newKeyboard = Keyboard.GetState();

        GetPressedKeys();

        oldKeyboard = newKeyboard;

        previousPressedKeys = new List<BitKey>();

        for (int i = 0; i < pressedKeys.Count; i++)
        {
            previousPressedKeys.Add(pressedKeys[i]);
        }
    }

    public bool GetKeyPress(string KEY)
    {
        for (int i = 0; i < pressedKeys.Count; i++)
        {
            if (pressedKeys[i].key == KEY)
            {
                return true;
            }
        }

        return false;
    }

    public void GetPressedKeys()
    {
        bool found = false;

        pressedKeys.Clear();

        for (int i = 0; i < newKeyboard.GetPressedKeys().Length; i++)
        {
            pressedKeys.Add(new BitKey(newKeyboard.GetPressedKeys()[i].ToString(), 1));
        }
    }

}