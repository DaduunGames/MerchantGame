using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerResources : MonoBehaviour
{
    public int maxHealth, health = 10;
    public float MaxStamina = 10;
    public int hunger, thirst = 5;
    public Vector3 pos = Vector3.zero;
    public Quaternion rot;

    private WagonFreeze wagon;

    private void Start()
    {
        Debug.Log("world was reset");
        GetResourceData();
        LoadPos();
        LoadWagon();
        LoadItems();
        StartCoroutine(CheckWagonFeeze());
    }

    private void GetResourceData()
    {
        maxHealth = GS.gameData.p_maxHealth;
        health = GS.gameData.p_health;
        hunger = GS.gameData.p_hunger;
        thirst = GS.gameData.p_thirst;
        pos = GS.gameData.p_pos;
        rot = GS.gameData.p_rot;
    }

    private void LoadPos()
    {
        transform.position = pos;
        transform.rotation = rot;

        print("setting player postion from saved data");
    }
    

    private void LoadWagon()
    {
        wagon = GameObject.FindObjectOfType<WagonFreeze>();
        wagon.transform.root.SetPositionAndRotation(GS.gameData.wagonSave.Pos, GS.gameData.wagonSave.Rot);
        
    }

    private IEnumerator CheckWagonFeeze()
    {
        if (GS.gameData.wagonSave.IsFrozen)
        {
            yield return new WaitForSeconds(0.5f);
            print("wagon should be frozen at start");
            wagon.IsFrozen = true;
            wagon.ForceFreeze();
        }
    }

    private void LoadItems()
    {
        foreach (ItemSave savedItem in GS.gameData.items)
        {
            ItemInstance instance = new ItemInstance();
            instance.init(savedItem.Name, savedItem.Amount, savedItem.Condition);
            GameObject spawnedItem = instance.CreatePhysicalItem(savedItem.Pos, savedItem.Rot);
        }
    }
}
