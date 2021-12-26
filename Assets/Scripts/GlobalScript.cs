using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalScript
{
    public static List<KeyCode> DefaultControls = new List<KeyCode>()
    {
        KeyCode.W,
        KeyCode.A,
        KeyCode.S,
        KeyCode.D,
        KeyCode.E,
        KeyCode.Space
    };

    public static List<KeyCode> SecondaryDefaults = new List<KeyCode>()
    {
        KeyCode.UpArrow,
        KeyCode.LeftArrow,
        KeyCode.DownArrow,
        KeyCode.RightArrow,
        KeyCode.None,
        KeyCode.None
    };

    //All the keybinds
    public static List<KeyCode> Controls = DefaultControls;
    public static List<KeyCode> SecondaryControls = SecondaryDefaults;
    

    
}
