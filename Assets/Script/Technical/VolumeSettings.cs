using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [Header("UI Sliders")]
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        musicSlider.value = VolumeManager.Instance.musicSource.volume;
        sfxSlider.value = VolumeManager.Instance.sfxSource.volume;

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMusicVolume(float volume)
    {
        VolumeManager.Instance.SetMusicVolume(volume);
    }

    public void SetSFXVolume(float volume)
    {
        VolumeManager.Instance.SetSFXVolume(volume);
    }
}