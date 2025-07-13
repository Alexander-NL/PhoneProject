using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    // Singleton setup
    private static BGMManager instance;

    [Header("BGM References")]
    public AudioClip defaultBGM;
    public AudioClip gameplayBGM;

    [Header("Special Scenes")]
    public string[] specialSceneNames;

    public AudioSource audioSource;

    private void Awake()
    {
        // Prevent duplicates
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void Start()
    {
        PlaySceneBGM(SceneManager.GetActiveScene().name);
    }

    private void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        PlaySceneBGM(newScene.name);
    }

    private void PlaySceneBGM(string sceneName)
    {
        // Skip if no BGM assigned
        if (defaultBGM == null && gameplayBGM == null)
        {
            Debug.LogWarning("No BGMs assigned!");
            return;
        }

        // Check if the current scene is in the special-scenes array
        bool useSpecialBGM = System.Array.Exists(specialSceneNames, scene => scene == sceneName);

        AudioClip targetBGM = useSpecialBGM ? gameplayBGM : defaultBGM;

        // Skip if already playing the correct BGM
        if (audioSource.clip == targetBGM && audioSource.isPlaying) return;

        audioSource.clip = targetBGM;
        audioSource.Play();
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }
}