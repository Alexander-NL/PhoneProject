using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    [Header("Object Reference")]
    public PlayerMovement playerMovement;

    [Header("Events Navigation")]
    public UnityEvent PlayersDead;
    public UnityEvent PlayerRespawned;
    public UnityEvent PlayerReset;

    [Header("Stats")]
    public float invulnerabilityDuration;

    public void StartPlayerReset()
    {
        if (playerMovement.isDead)
        {
            playerMovement.isDead = false;
        }
        if (playerMovement.playerWon)
        {
            playerMovement.playerWon = false;
        }
        PlayerReset.Invoke();
    }
}
