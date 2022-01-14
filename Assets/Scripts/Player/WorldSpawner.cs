using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawner : MonoBehaviour
{
    public GameObject defaultPlayer;

   

    private void Update()
    {
        if (GS.gameData.IsSet) 
        {
            GS.gameData.IsSet = false;

            spawnItems();

            if (GS.gameData.player)
            {
                print("test");
                PlayerMovement foundPlayer = GS.gameData.player;
                Instantiate(foundPlayer.thisObj, foundPlayer.transform.position, foundPlayer.transform.rotation);
            }
            else
            {
                Instantiate(defaultPlayer, transform.position, Quaternion.identity);
            }
        }

        //temp save and load keys
        if (Input.GetKeyDown(KeyCode.O))
        {
            GS.SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            GS.LoadGame();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GS.keybinds.Secondary[(int)GS.Binds.Interact] = KeyCode.T;
        }

    }

    public void spawnItems()
    {
        if (GS.gameData.items != null)
        {
            foreach (GameObject item in GS.gameData.items)
            {
                GameObject i = item;
                Instantiate(i, i.transform.position, i.transform.rotation);
            }
        }
    }
}
