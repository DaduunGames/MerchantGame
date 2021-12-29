using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemDB 
{
    public enum eName
    {
        empty,
        cloth,
        fruits,
        pinapple,
        Wool
    }

    public static List<ItemCore> Library =
        new List<ItemCore>() {
            new ItemCore(eName.empty,"0","empty", -999),
            new ItemCore(eName.pinapple,"1","item1", 30),
            new ItemCore(eName.fruits,"2","item2", 25),
            new ItemCore(eName.cloth,"3","item3", 25),
            new ItemCore(eName.Wool, "0","Blocc", 10)
            };





    //no touchy

    public static ItemCore GetCore(eName name)
    {
        return Library[(int)name];
    }

    public static GameObject GetPhysicalBase()
    {
        return Resources.Load<GameObject>("Physical Item");
    }

    public static void GetMeshForItem(eName name)
    {

    }
}
