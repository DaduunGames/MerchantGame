using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemInstance : ItemCore
{
    public int Amount;
    [Range(0,100)]
    public float Condition;

    public void init(ItemDB.eName name, int amount, float condition)
    {
        Amount = amount;
        Condition = condition;

        ItemCore item = ItemDB.GetCore(name);

        init(item.Name, item.Image, item.Prefab, item.MarketValue);
    }

    public GameObject CreatePhysicalItem(Vector3 pos, Quaternion rot)
    {
        GameObject real = Instantiate(ItemDB.GetPhysicalBase(), pos, rot);
        real.GetComponent<PhysicalItem>().init(this);

        GameObject mesh = GetMesh();
        Instantiate(mesh, pos, rot, real.transform);

        return real;
    }

    public GameObject GetMesh()
    {
        return Resources.Load<GameObject>("Mesh/" + Prefab);
    }
}
