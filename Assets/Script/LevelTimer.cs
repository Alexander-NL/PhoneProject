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

    // Call this to start/resume the timer
    public void StartTimer()
    {
        if (!_isTimerRunning)
        {
            _startTime = Time.time - _elapsedTime; // Adjust for pauses
            _isTimerRunning = true;
            Debug.Log("Timer STARTED");
        }
    }

    // Call this to pause/stop the timer
    public void StopTimer()
    {
        if (_isTimerRunning)
        {
            _elapsedTime = Time.time - _startTime;
            _isTimerRunning = false;
            Debug.Log("Timer STOPPED");
        }
    }

    // Call this to get the current time (formatted)
    public string GetFormattedTime()
    {
        float currentTime = _isTimerRunning ? Time.time - _startTime : _elapsedTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
        return $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
    }

    // Example usage in Update (optional)
    private void Update()
    {
        if (_isTimerRunning)
        {
            Debug.Log("Current time: " + GetFormattedTime());
        }
    }
}