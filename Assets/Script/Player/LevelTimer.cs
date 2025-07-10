using UnityEngine;
using System; // For TimeSpan

public class LevelTimer : MonoBehaviour
{
    private float _startTime;
    private float _elapsedTime;
    private bool _isTimerRunning;

    private void Start()
    {
        StartTimer();
    }

    /// <summary>
    /// Start timer
    /// </summary>
    public void StartTimer()
    {
        if (!_isTimerRunning)
        {
            _startTime = Time.time - _elapsedTime;
            _isTimerRunning = true;
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
        if (_isTimerRunning)
        {
            _elapsedTime = Time.time - _startTime;
            _isTimerRunning = false;
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
        _elapsedTime = 0f;
        _startTime = Time.time;

        if (!keepRunning)
        {
            _isTimerRunning = false;
            Debug.Log("Timer RESET (stopped)");
        }
        else
        {
            _isTimerRunning = true;
            Debug.Log("Timer RESET (running)");
        }
    }

    /// <summary>
    /// getting the formatted time of min and sec
    /// </summary>
    /// <returns></returns>
    public string GetFormattedTime()
    {
        float currentTime = _isTimerRunning ? Time.time - _startTime : _elapsedTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
        return $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
    }
}