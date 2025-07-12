using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    [Header("Events Navigation")]
    public UnityEvent PlayersDead;
    public UnityEvent PlayerRespawned;
    public UnityEvent PlayerReset;

    [Header("Stats")]
    public float invulnerabilityDuration;

    public void StartPlayerReset()
    {
        PlayerReset.Invoke();
    }
}
