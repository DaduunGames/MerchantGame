using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCore : ScriptableObject
{
    public ItemDB.eName Name;
    public string Image = "";
    public string Prefab = "";
    public float MarketValue = -999;

    public ItemCore(ItemDB.eName name, string image, string Prefab, float marketValue)
    {
        Name = name;
        Image = image;
        this.Prefab = Prefab;
        MarketValue = marketValue;

        Debug.ClearDeveloperConsole();
    }
    public ItemCore()
    {
    }

    public void init(ItemDB.eName name, string image, string mesh, float marketValue)
    {
        Name = name;
        Image = image;
        Prefab = mesh;
        MarketValue = marketValue;
    }
    
}