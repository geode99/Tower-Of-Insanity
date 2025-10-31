using System.IO;
using UnityEngine;

public class SaveDataController : MonoBehaviour
{
    public string SaveFilePath;
    public string SaveFileName;

    public SaveDataAsset Defualt;
    public static SaveData Current;

    public void SaveGame()
    {
        Debug.Log("Game Saved!");
        Serializer.Save(Current, Path.Combine(Application.persistentDataPath, SaveFilePath), SaveFileName);
    }

    public void LoadGame()
    {
        Debug.Log("Game Loaded!");
        Current = Serializer.Load(Defualt.saveData, Path.Combine(Application.persistentDataPath, SaveFilePath), SaveFileName);
    }

    private void Awake()
    {
        LoadGame();
    }
    private void OnDestroy()
    {
        SaveGame();
    }
}

