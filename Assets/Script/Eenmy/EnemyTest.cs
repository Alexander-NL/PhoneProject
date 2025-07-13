using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    [SerializeField] BoxCollider2D box2d;
    public void PlayerInvulnerable()
    {
        box2d.enabled = !box2d.enabled;
        Debug.Log("Event turned on");
    }

    public void TurnOffBox()
    {
        box2d.enabled = false;
    }

    public void TurnOnBox()
    {
        box2d.enabled = true;
    }
}
