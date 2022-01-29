using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public static class GS
{
    public static float MouseXSensativity = 1f;
    public static float MouseYSensativity = 1f;
    public static bool InvertPitch = false;
    

    public enum Binds
    {
        //enums used with static Controls[] list.

        WalkForwards = 0,
        WalkLeft = 1,
        WalkBackwards = 2,
        WalkRight = 3,
        Interact = 4,
        Jump = 5,
        Pickup = 6
    }

    public static List<KeyCode> DefaultControls = new List<KeyCode>()
    {
        KeyCode.W,
        KeyCode.A,
        KeyCode.S,
        KeyCode.D,
        KeyCode.E,
        KeyCode.Space,
        KeyCode.Mouse0
    };

    public static List<KeyCode> SecondaryDefaults = new List<KeyCode>()
    {
        KeyCode.UpArrow,
        KeyCode.LeftArrow,
        KeyCode.DownArrow,
        KeyCode.RightArrow,
        KeyCode.F,
        KeyCode.None,
        KeyCode.None
    };

    //All the keybinds
    public static Keybinds keybinds = new Keybinds();

    public static Keybinds GetKeybinds()
    {
        return keybinds;
    }
    public static void SetKeybinds(Keybinds newKeybinds)
    {
        keybinds = newKeybinds;
    }
    public static void SetKeybindsDefault()
    {
        keybinds.Primary = DefaultControls;
        keybinds.Secondary = SecondaryDefaults;
    }



    // game save functionality

    public static GameData gameData = new GameData();
    private static string filePath = Application.persistentDataPath + "/GameSave.json";
    
    public static void SaveGame()
    {
        //Debug.Log(filePath);

        Debug.Log("saving game");
        gameData.GetWorld();
        string data = JsonUtility.ToJson(gameData);
        File.WriteAllText(filePath, "");
        File.WriteAllText(filePath, data);

    }
    public static void LoadGame(int index)
    {
        //Debug.Log("Loading game");
        if (File.Exists(filePath))
        {
            string foundData = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(foundData);
           
        }
        SceneManager.LoadScene(index);
        gameData.SetWorld();
        
    }

    public static void ClearSaveData()
    {
        File.WriteAllText(filePath, "");
    }


}

[System.Serializable]
public class Keybinds
{
    public List<KeyCode> Primary = GS.DefaultControls;
    public List<KeyCode> Secondary = GS.SecondaryDefaults;
}
