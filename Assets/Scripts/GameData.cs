using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData
{
    public bool IsSet = false;

    public Keybinds savedKeybinds = new Keybinds();

    public int p_maxHealth, p_health, p_hunger, p_thirst;
    public float p_maxStamina;
    public Vector3 p_pos;
    public Quaternion p_rot;

    public List<ItemSave> items = new List<ItemSave>();

    public WagonSave wagonSave = new WagonSave();


    public void GetWorld()
    {
        GetSettings();

        PlayerResources playerResources = Object.FindObjectOfType<PlayerResources>();
        
        p_maxHealth = playerResources.maxHealth;
        p_health = playerResources.health;
        p_hunger = playerResources.hunger;
        p_thirst = playerResources.thirst;
        p_maxStamina = playerResources.MaxStamina;
        p_pos = playerResources.transform.position;
        p_rot = playerResources.transform.rotation;

        WagonFreeze foundWagon = GameObject.FindObjectOfType<WagonFreeze>();
        wagonSave = new WagonSave(foundWagon.transform.root.position, foundWagon.transform.root.rotation, foundWagon.IsFrozen);


        PhysicalItem[] foundItems = GameObject.FindObjectsOfType<PhysicalItem>();
        items.Clear();
        foreach (PhysicalItem item in foundItems)
        {
            items.Add(new ItemSave( item.transform.position, item.transform.rotation, item.itemInstance.Name, item.itemInstance.Amount, item.itemInstance.Condition));
        }


    }

    public void SetWorld()
    {

        SetSettings();

        IsSet = true;    
    }

    public void GetSettings()
    {
        savedKeybinds = GS.GetKeybinds();
    }
    public void SetSettings()
    {
        GS.SetKeybinds(savedKeybinds);
    }
}
