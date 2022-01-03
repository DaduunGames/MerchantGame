using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldButton : TriggerCore
{
    public UnityEvent[] Events;
    public override void Interact()
    {
        foreach (UnityEvent Event in Events)
        {
            Event.Invoke();
        }
    }
}
