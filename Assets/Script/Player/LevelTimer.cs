using UnityEngine;
using System;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    private float startTime;
    private float elapsedTime;
    private bool isTimerRunning;
    private float nextUpdateTime;
    private bool isPaused;
    private float pauseStartTime;

    [SerializeField] private TMP_Text TimeText;
    [SerializeField] private float updateInterval = 0.1f;

    private void Start()
    {
        StartTimer();
    }

    private void Update()
    {
        if (isTimerRunning && !isPaused && Time.time >= nextUpdateTime)
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
        isPaused = false;
        UpdateTimerDisplay();

        isTimerRunning = keepRunning;
        Debug.Log($"Timer RESET ({(keepRunning ? "running" : "stopped")})");
    }


    /// <summary>
    /// all bcuz of the stupid bool = !bool situation that i cant prob fix in time
    /// </summary>
    //public void ButtonPauseFunction()
    //{
    //    if (isPaused)
    //    {
    //        ResumeTimer();
    //    }
    //    else
    //    {
    //        PauseTimer();
    //    }
    //}

    /// <summary>
    /// yep as the name says
    /// </summary>
    public void PauseTimer()
    {
        if (isTimerRunning && !isPaused)
        {
            isPaused = true;
            pauseStartTime = Time.time;
            Debug.Log("Timer PAUSED");
        }
    }

    /// <summary>
    /// yep as the name says^2
    /// </summary>
    public void ResumeTimer()
    {
        if (isPaused)
        {
            // Add the pause duration to startTime to compensate
            startTime += Time.time - pauseStartTime;
            isPaused = false;
            Debug.Log("Timer RESUMED");
        }
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