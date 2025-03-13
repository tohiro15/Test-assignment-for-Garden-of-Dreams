using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private const string SAVE_PATH = "/buildings.json";

    public void SaveBuildings(BuildingsData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + SAVE_PATH, json);
        Debug.Log("Buildings saved!");
    }

    public BuildingsData LoadBuildings()
    {
        if (File.Exists(Application.persistentDataPath + SAVE_PATH))
        {
            string json = File.ReadAllText(Application.persistentDataPath + SAVE_PATH);
            return JsonUtility.FromJson<BuildingsData>(json);
        }
        Debug.Log("No save file found.");
        return null;
    }
}