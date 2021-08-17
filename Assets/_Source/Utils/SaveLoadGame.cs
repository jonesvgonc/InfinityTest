using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveLoadGame 
{
    private static string _fullpath = Application.persistentDataPath + "//Saves//powerEnergy.json";
    private static string _folder = Application.persistentDataPath + "//Saves//";

    public static void SaveGame(PlayerStats data)
    {
        var playerData = JsonUtility.ToJson(data);

        if (!Directory.Exists(_folder))
        {
            Directory.CreateDirectory(_folder);
        }

        File.WriteAllText(_fullpath, playerData);
    }

    public static PlayerStats LoadGame()
    {
        if (Directory.Exists(_folder))
        {
            var playerData = JsonUtility.FromJson<PlayerStats>(File.ReadAllText(_fullpath));
            return playerData;
        }

        return null;
    }
}
