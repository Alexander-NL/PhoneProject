using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Fruit : MonoBehaviour
{
    [SerializeField] LayerMask PlayerLayer;
    [SerializeField] BoxCollider2D box;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private float Delay = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayer(collision.gameObject))
        {
            box.enabled = false;
            spriteRenderer.enabled = false;
            StartCoroutine(DelayDisapear());
        }
    }

    IEnumerator DelayDisapear()
    {
        yield return new WaitForSeconds(Delay);
        box.enabled = true;
        spriteRenderer.enabled = true;   
    }

    private bool IsPlayer(GameObject obj)
    {
        return PlayerLayer == (PlayerLayer | (1 << obj.layer));
    }
}
