using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemConstruct 
{
    public ItemDB.eName Name;
    public int Amount;
    [Range(0,100)]
    public float Condition;
}
