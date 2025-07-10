using UnityEngine;

public class ForceResolution : MonoBehaviour
{
    [SerializeField] private int _targetWidth = 1920;   // Default target resolution
    [SerializeField] private int _targetHeight = 1080;
    [SerializeField] private bool _fullscreen = false;  // Fullscreen or windowed
    [SerializeField] private int _refreshRateNumerator = 60;  // Refresh rate (e.g., 60Hz)
    [SerializeField] private int _refreshRateDenominator = 1;  // Usually 1 for standard rates

    private void Start()
    {
        // Create a RefreshRate struct
        RefreshRate refreshRate = new RefreshRate()
        {
            numerator = (uint)_refreshRateNumerator,
            denominator = (uint)_refreshRateDenominator
        };

        // Set the resolution with the new RefreshRate parameter
        Screen.SetResolution(
            _targetWidth,
            _targetHeight,
            _fullscreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed,
            refreshRate
        );

        // Optional: Lock framerate to match refresh rate
        Application.targetFrameRate = (int)refreshRate.numerator;
    }
}