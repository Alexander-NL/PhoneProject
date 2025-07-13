using UnityEngine;
using System.IO;

public class InfoHolder : MonoBehaviour
{
    public static InfoHolder Instance;
    public int CurrentLevel;
    public int Currency;

    private string savePath;

    [System.Serializable]
    private class SaveData
    {
        public int savedLevel;
        public int savedCurrency;
    }

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Initialize()
    {
        savePath = Path.Combine(Application.persistentDataPath, "game_data.json");
        LoadData();
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData
        {
            savedLevel = CurrentLevel,
            savedCurrency = Currency
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);

        Debug.Log($"Game saved to: {savePath}");
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            CurrentLevel = data.savedLevel;
            Currency = data.savedCurrency;

            Debug.Log("Game data loaded");
        }
        else
        {
            Debug.Log("No save file found. Using defaults.");
            CurrentLevel = 1; // Default starting level
            Currency = 0;     // Default starting currency
        }
    }

    // Example usage:
    public void AddCurrency(int amount)
    {
        Currency += amount;
        SaveGameData(); // Auto-save when currency changes
    }

    public void ProgressToNextLevel()
    {
        CurrentLevel++;
        SaveGameData(); // Auto-save when level changes
    }
}