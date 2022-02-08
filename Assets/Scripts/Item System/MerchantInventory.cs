using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MerchantInventory : MonoBehaviour
{
    public List<ItemConstruct> InventoryConstructor;
    public List<ItemInstance> Inventory;

    public Transform spawnZone;

    private void Start()
    {
        foreach(ItemConstruct ic in InventoryConstructor)
        {
            ItemInstance inst = ScriptableObject.CreateInstance(typeof(ItemInstance)) as ItemInstance;
            inst.init(ic.Name, ic.Amount, ic.Condition);
            Inventory.Add(inst);
        }
    }


    public void spawnItem(int index)
    {
        Inventory[index].CreatePhysicalItem(spawnZone.position , spawnZone.rotation);
    }


    
}
