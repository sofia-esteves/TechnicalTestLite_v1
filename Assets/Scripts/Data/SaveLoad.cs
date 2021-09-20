using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Assets.Scripts.Data;

public static class SaveLoad 
{
    /// <summary>
    /// Static class, with Save, Load and Clear Methods.
    /// Converts game data to a format that can be saved and later restored
    /// </summary>
    public static LevelProgress savedProgress = new LevelProgress();

    public static void Save()
    {
        SaveLoad.savedProgress= LevelProgress.Current;
        BinaryFormatter bf = new BinaryFormatter();
        
        FileStream file = File.Create(Application.persistentDataPath + "/savedProgress.gd");
        bf.Serialize(file, SaveLoad.savedProgress);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedProgress.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedProgress.gd", FileMode.Open);
            SaveLoad.savedProgress = (LevelProgress)bf.Deserialize(file);
            file.Close();
        }
    }

    public static void Clear()
    {
        if(File.Exists(Application.persistentDataPath + "/savedProgress.gd"))
        {
            File.Delete(Application.persistentDataPath + "/savedProgress.gd");
        }
    }
}
