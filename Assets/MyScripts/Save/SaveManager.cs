using UnityEngine;
using System.Collections.Generic;
using System.IO;

public static class SaveManager
{
    public static SaveData save = new();
    static readonly string saveDataPath = Application.persistentDataPath + "/SaveData.json";

    public static void Save()
    {
        string saveDatajson = JsonUtility.ToJson(save);
        Debug.Log(saveDatajson);
        File.WriteAllText(saveDataPath, saveDatajson);
    }

    public static string Load()
    {
        string loadJson = File.ReadAllText(saveDataPath);
        save = JsonUtility.FromJson<SaveData>(loadJson);
        return loadJson;
    }
}

[System.Serializable]
public class SaveData
{
    public int progress = 0;
    public int[] highScores = new int[5];
}