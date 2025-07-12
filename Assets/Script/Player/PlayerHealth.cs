using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerHealth : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] private PlayerStats stats;
    [SerializeField] private LevelTimer levelTimer;
    [SerializeField] private PlayerEvents playerEvents;
    [SerializeField] private PlayerScoreManager scoreManager;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CoinManger coinManager;

    [Header("Location Reference")]
    [SerializeField] private Transform PlayerRespawn;

    [Header("Stast")]
    [SerializeField] private int MaxHP;
    [SerializeField] private int CurrHP;

    private void Start()
    {
        MaxHP = stats.maxHP;
        CurrHP = MaxHP;
    }

    /// <summary>
    /// Basic ahh reduce HP function
    /// </summary>
    //DONT PUT THE IF IN VOID UPDATE TRUST ME SHI GOES CRAZY
    public void ReduceHP()
    {
        CurrHP--;
        if (CurrHP == 0)
        {
            //player Dead function
            playerMovement.IsDead();

            //Update and reset temp score if player dead
            string time = levelTimer.StopTimer();
            scoreManager.UpdateScore(coinManager.score, time);
            coinManager.score = 0;
            levelTimer.ResetTimer();

            //invoke event if player dead
            playerEvents.PlayersDead.Invoke();
        }
        else
        {
            RespawnPlayer();
        }
    }

    /// <summary>
    /// Respawn player on transform when function is referenced
    /// </summary>
    public void RespawnPlayer()
    {
        if(PlayerRespawn == null)
        {
            Debug.LogError("Respawn point not assigned!");
            return;
        }

        transform.position = PlayerRespawn.position;
        playerMovement.canChangeDirection = true;
        StartCoroutine(InvulnerabilityTimer());
    }

    IEnumerator InvulnerabilityTimer()
    {
        playerEvents.PlayerRespawned.Invoke();
        yield return new WaitForSeconds(playerEvents.invulnerabilityDuration);
        playerEvents.PlayerRespawned.Invoke();
    }
}
