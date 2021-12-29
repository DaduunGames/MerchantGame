using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalItem : MonoBehaviour
{
    public ItemInstance itemInstance;

    //public ItemDB.eName Name;
    //public int Amount;
    //[Range(0,100)]
    //public float Condition;

    //public void init(ItemDB.eName name, int amount, float condition)
    //{
    //    Name = name;
    //    Amount = amount;
    //    Condition = condition;
    //}

    public void init(ItemInstance item)
    {
        itemInstance = item;
    }


}
