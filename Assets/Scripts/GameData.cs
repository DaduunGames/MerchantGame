using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData
{
    public bool IsSet = false;
    public Keybinds savedKeybinds = new Keybinds();
    public PlayerMovement player = new PlayerMovement();
    public GameObject[] items = new GameObject[0];

    public void GetWorld()
    {
        savedKeybinds = GS.GetKeybinds();
        player = Object.FindObjectOfType<PlayerMovement>();


        //if (GameObject.FindWithTag("ItemObject"))
        //{
        //    items = GameObject.FindGameObjectsWithTag("ItemObject");
        //}

    }

    public void SetWorld()
    {
        GS.SetKeybinds(savedKeybinds);
        

        IsSet = true;    
    }

}
