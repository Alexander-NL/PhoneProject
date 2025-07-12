using UnityEngine;

public class InfoHolder : MonoBehaviour
{
    public static InfoHolder Instance; // Singleton pattern
    public int CurrentLevel;

    public int Currency;

    private void Awake()
    {
        // Prevent duplicates and set up singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate
            return;
        }
    }

    // Function to be called by UnityEvent
    public void DoSomething()
    {
        Debug.Log("Persistent object function called!");
    }
}
