using UnityEngine;
using UnityEngine.SceneManagement;

public class VolumeManager : MonoBehaviour
{
    public static VolumeManager Instance { get; private set; }

    [Header("Audio Sources")]
    public GameObject bgmSource;
    public AudioSource musicSource;
    public GameObject sfxObject;
    public AudioSource sfxSource;

    [SerializeField] private InfoHolder infoHolder;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadVolumes();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    private void OnSceneChanged(Scene current, Scene next)
    {
        bgmSource = GameObject.Find("BGMManager");
        musicSource = bgmSource.GetComponent<AudioSource>();
        sfxObject = GameObject.Find("SFXUI");
        sfxSource = sfxObject.GetComponent<AudioSource>();
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolumes()
    {
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.2f); // Default 70%
        sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume", 0.2f);    // Default 70%
    }
}