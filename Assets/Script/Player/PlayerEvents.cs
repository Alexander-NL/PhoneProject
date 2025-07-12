using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    [Header("Events Navigation")]
    public UnityEvent PlayersDead;
    public UnityEvent PlayerRespawned;

    [Header("Stats")]
    public float invulnerabilityDuration;


}
