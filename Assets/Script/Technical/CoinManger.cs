using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class CoinManger : MonoBehaviour
{
    [Header("Object Reference")]
    public PlayerScoreManager scoreManager;

    [Header("Collection Settings")]
    [SerializeField] private GameObject[] collectibles;
    [SerializeField] private Fruit[] ScriptList;

    [Header("Events")]
    public UnityEvent OnAllCollected;

    public int score;
    private bool[] collectedStatus;
    private int remainingCount;

    private void Awake()
    {
        collectedStatus = new bool[collectibles.Length];
        remainingCount = collectibles.Length;

        collectibles = collectibles.Where(x => x != null).ToArray();
    }

    public void RegisterCollection(GameObject collectedObject)
    {
        for (int i = 0; i < collectibles.Length; i++)
        {
            if (collectibles[i] == collectedObject && !collectedStatus[i])
            {
                collectedStatus[i] = true;
                remainingCount--;
                score++;

                Debug.Log($"Collected: {collectibles.Length - remainingCount}/{collectibles.Length}");

                if (remainingCount <= 0)
                {
                    OnAllCollected.Invoke();
                    Debug.Log("ALL ITEMS COLLECTED!");
                }
                return;
            }
        }
    }
    public void ResetAllCoins()
    {
        // Reset tracking variables
        remainingCount = collectibles.Length;
        collectedStatus = new bool[collectibles.Length];
        score = 0;

        // Call Reset function on each Fruit
        foreach (Fruit fruit in ScriptList)
        {
            if (fruit != null)
            {
                fruit.TurnedON(); // Call your reset function
            }
        }

        Debug.Log($"Reset all {ScriptList.Length} fruits/coins");
    }
}
