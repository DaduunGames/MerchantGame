using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInputs : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GS.SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GS.LoadGame(1);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GS.ClearSaveData();
        }
    }
}
