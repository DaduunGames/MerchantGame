using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WagonSave 
{
    public Vector3 Pos;
    public Quaternion Rot;
    public bool IsFrozen;

    public WagonSave(Vector3 pos, Quaternion rot, bool isFrozen)
    {
        Pos = pos;
        Rot = rot;
        IsFrozen = isFrozen;
    }

    public WagonSave()
    {

    }
}
