using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GS
{
    public static float MouseXSensativity = 10;
    public static float MouseYSensativity = 10;
    public static bool InvertPitch = false;

    public enum Binds
    {
        //enums used with static Controls[] list.

        WalkForwards = 0,
        WalkLeft = 1,
        WalkBackwards = 2,
        WalkRight = 3,
        Interact = 4,
        Jump = 5,
        Pickup = 6
    }

    public static List<KeyCode> DefaultControls = new List<KeyCode>()
    {
        KeyCode.W,
        KeyCode.A,
        KeyCode.S,
        KeyCode.D,
        KeyCode.E,
        KeyCode.Space,
        KeyCode.Mouse0
    };

    public static List<KeyCode> SecondaryDefaults = new List<KeyCode>()
    {
        KeyCode.UpArrow,
        KeyCode.LeftArrow,
        KeyCode.DownArrow,
        KeyCode.RightArrow,
        KeyCode.F,
        KeyCode.None,
        KeyCode.None
    };

    //All the keybinds
    public static List<KeyCode> Controls = DefaultControls;
    public static List<KeyCode> SecondaryControls = SecondaryDefaults;

    
    
}
