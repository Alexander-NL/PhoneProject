using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    [SerializeField] BoxCollider2D box2d;
    public void PlayerInvulnerable()
    {
        box2d.enabled = !box2d.enabled;
        Debug.Log("Event turned on");
    }
}
