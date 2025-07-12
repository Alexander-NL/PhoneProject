using UnityEngine;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class LevelRecord
{
    public int level;
    public string bestTime;
    public int bestScore;  // Tracked separately from bestTime
}

[System.Serializable]
public class GameSaveData
{
    public List<LevelRecord> levelRecords = new List<LevelRecord>();
}

public class PlayerScoreManager : MonoBehaviour
{
    [Header("Current Stats")]
    public int currentScore;
    public string currentTime;
    public int currentLevel;

    [Header("Best Stats")]
    public int bestScore;
    public string bestTime;

    [Header("Object Reference")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject infoHolderObject;
    [SerializeField] private InfoHolder infoHolder;

    private string savePath;
    private GameSaveData saveData;

    private void Start()
    {
        infoHolderObject = GameObject.Find("InfoHolder");
        infoHolder = infoHolderObject.GetComponent<InfoHolder>();

        savePath = Path.Combine(Application.persistentDataPath, "level_records.json");
        saveData = new GameSaveData();
        LoadRecords();
    }

    public void ResetCurrScore()
    {
        currentScore = 0;
        currentTime = "00:00";
        currentLevel = infoHolder.CurrentLevel;
    }

    public void UpdateScore(int score, string time)
    {
        currentScore = score;
        currentTime = time;
        currentLevel = infoHolder.CurrentLevel;
        SaveRecords();
    }

    private void SaveRecords()
    {
        var record = saveData.levelRecords.Find(x => x.level == currentLevel);
        bool newTimeRecord = false;
        bool newScoreRecord = false;

        // Initialize if no record exists
        if (record == null)
        {
            record = new LevelRecord { level = currentLevel };
            saveData.levelRecords.Add(record);
            newTimeRecord = true;
            newScoreRecord = true;
        }

        // Check for new best time (independent of score)
        if (CompareTimes(currentTime, record.bestTime))
        {
            record.bestTime = currentTime;
            newTimeRecord = true;
        }

        // Check for new best score (independent of time)
        if (currentScore > record.bestScore)
        {
            record.bestScore = currentScore;
            newScoreRecord = true;
        }

        // Only save if something changed
        if (newTimeRecord || newScoreRecord)
        {
            SaveToFile();
            
            Debug.Log($"Best Time: {record?.bestTime ?? "N/A"}");
            Debug.Log($"Best Score: {record?.bestScore ?? 0}");
        }

        bestTime = record.bestTime;
        bestScore = record.bestScore;
    }

    public void ResetLevelRecords(int level)
    {
        saveData.levelRecords.RemoveAll(x => x.level == level);
        SaveToFile();
    }

    public LevelRecord GetLevelRecord(int level)
    {
        return saveData.levelRecords.Find(x => x.level == level);
    }

    private bool CompareTimes(string newTime, string oldTime)
    {
        return string.IsNullOrEmpty(oldTime) || string.Compare(newTime, oldTime) < 0;
    }

    private void LoadRecords()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            saveData = JsonUtility.FromJson<GameSaveData>(json) ?? new GameSaveData();
        }
    }

    private void SaveToFile()
    {
        File.WriteAllText(savePath, JsonUtility.ToJson(saveData, true));
    }
}