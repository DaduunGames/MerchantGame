using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MerchantInventory : MonoBehaviour
{
    public List<ItemConstruct> InventoryConstructor;
    public List<ItemInstance> Inventory;

    private void Start()
    {
        foreach(ItemConstruct ic in InventoryConstructor)
        {
            ItemInstance inst = ScriptableObject.CreateInstance(typeof(ItemInstance)) as ItemInstance;
            inst.init(ic.Name, ic.Amount, ic.Condition);
            Inventory.Add(inst);
        }


        foreach (ItemInstance item in Inventory)
        {
            print($"found item with the following parameters:" +
                $"\nName: {item.Name}" +
                $"\nAmmount: {item.Amount}" +
                $"\nCondition: {item.Condition}" +
                $"\nMarket Value: {item.MarketValue}" +
                $"\nImage: {item.Image}" +
                $"\nPrefab: {item.Prefab}");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Inventory[0].CreatePhysicalItem( transform.position + transform.rotation * new Vector3(0, 1, 2), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Inventory[1].CreatePhysicalItem( transform.position + transform.rotation * new Vector3(0, 1, 2), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Inventory[2].CreatePhysicalItem( transform.position + transform.rotation * new Vector3(0, 1, 2), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Inventory[3].CreatePhysicalItem( transform.position + transform.rotation * new Vector3(0, 1, 2), Quaternion.identity);
        }
    }
}
