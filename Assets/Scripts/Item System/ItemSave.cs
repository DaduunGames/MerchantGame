using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemSave : ItemConstruct
{
    public Vector3 Pos;
    public Quaternion Rot;

    public ItemSave(Vector3 pos, Quaternion rot, ItemDB.eName name, int amount, float condition)
    {
        Pos = pos;
        Rot = rot;
        Name = name;
        Amount = amount;
        Condition = condition;
    }
}
