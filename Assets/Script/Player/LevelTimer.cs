using UnityEngine;
using System;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    private float startTime;
    private float elapsedTime;
    private bool isTimerRunning;
    private float nextUpdateTime;

    [SerializeField] private TMP_Text TimeText;
    [SerializeField] private float updateInterval = 0.1f;

    private void Start()
    {
        StartTimer();
    }

    private void Update()
    {
        if (isTimerRunning && Time.time >= nextUpdateTime)
        {
            UpdateTimerDisplay();
            nextUpdateTime = Time.time + updateInterval;
        }
    }

    /// <summary>
    /// Start timer
    /// </summary>
    public void StartTimer()
    {
        if (!isTimerRunning)
        {
            startTime = Time.time - elapsedTime;
            isTimerRunning = true;
            UpdateTimerDisplay();
            Debug.Log("Timer STARTED");
        }
    }

    /// <summary>
    /// Stop timer
    /// </summary>
    /// <returns>
    /// Return string of formatted time
    /// </returns>
    public string StopTimer()
    {
        if (isTimerRunning)
        {
            elapsedTime = Time.time - startTime;
            isTimerRunning = false;
            string formattedTime = GetFormattedTime();
            Debug.Log($"Timer STOPPED at: {formattedTime}");
            return formattedTime;
        }
        return GetFormattedTime();
    }

    /// <summary>
    /// Reset the timer
    /// </summary>
    /// <param name="keepRunning"></param>
    public void ResetTimer(bool keepRunning = false)
    {
        elapsedTime = 0f;
        startTime = Time.time;
        UpdateTimerDisplay(); // Immediate update

        isTimerRunning = keepRunning;
        Debug.Log($"Timer RESET ({(keepRunning ? "running" : "stopped")})");
    }

    /// <summary>
    /// getting the formatted time of min and sec
    /// </summary>
    /// <returns></returns>
    public string GetFormattedTime()
    {
        float currentTime = isTimerRunning ? Time.time - startTime : elapsedTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
        return $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
    }

    private void UpdateTimerDisplay()
    {
        if (TimeText != null)
        {
            TimeText.text = GetFormattedTime();
        }
    }
}