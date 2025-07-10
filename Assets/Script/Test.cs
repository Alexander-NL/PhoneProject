using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
    [System.Serializable]
    public class LevelData
    {
        public List<ScoreEntry> topScores = new List<ScoreEntry>();
    }

    [System.Serializable]
    public class ScoreEntry
    {
        public int score;
        public string time;
    }

    [System.Serializable]
    private class SaveData
    {
        public LevelData[] levelStats = new LevelData[3]; // For 3 levels
    }

    private SaveData allStats;
    private string savePath;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "level_stats.json");
        LoadStats(); // Load existing data when the game starts
    }

    // Call this when a level is completed
    public void AddScoreForLevel(int levelIndex, int newScore, string newTime)
    {
        // Initialize if null (first run)
        if (allStats.levelStats[levelIndex] == null)
        {
            allStats.levelStats[levelIndex] = new LevelData();
        }

        // Add new entry
        ScoreEntry entry = new ScoreEntry { score = newScore, time = newTime };
        allStats.levelStats[levelIndex].topScores.Add(entry);

        // Sort by score (descending) and keep only top 3
        allStats.levelStats[levelIndex].topScores.Sort((a, b) => b.score.CompareTo(a.score));
        if (allStats.levelStats[levelIndex].topScores.Count > 3)
        {
            allStats.levelStats[levelIndex].topScores.RemoveRange(3, allStats.levelStats[levelIndex].topScores.Count - 3);
        }

        SaveStats();
    }

    private void SaveStats()
    {
        try
        {
            string json = JsonUtility.ToJson(allStats, true);
            File.WriteAllText(savePath, json);
            Debug.Log("Saved stats to: " + savePath);
        }
        catch (Exception e)
        {
            Debug.LogError("Save failed: " + e.Message);
        }
    }

    private void LoadStats()
    {
        if (File.Exists(savePath))
        {
            try
            {
                string json = File.ReadAllText(savePath);
                allStats = JsonUtility.FromJson<SaveData>(json);
            }
            catch (Exception e)
            {
                Debug.LogError("Load failed: " + e.Message);
                allStats = new SaveData();
            }
        }
        else
        {
            allStats = new SaveData();
        }

        // Initialize all levels if null
        for (int i = 0; i < 3; i++)
        {
            if (allStats.levelStats[i] == null)
            {
                allStats.levelStats[i] = new LevelData();
            }
        }
    }

    // Get top scores for a specific level (for UI display)
    public List<ScoreEntry> GetTopScores(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < 3)
        {
            return allStats.levelStats[levelIndex].topScores;
        }
        return new List<ScoreEntry>();
    }
}