using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Fruit : MonoBehaviour
{
    [SerializeField] LayerMask PlayerLayer;
    [SerializeField] BoxCollider2D box;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private CoinManger coinManager;
    [SerializeField] private SkillButton skillButton;

    [SerializeField] private bool IsTicket;

    //[SerializeField] private float Delay = 10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayer(collision.gameObject) && !IsTicket)
        {
            spriteRenderer.enabled = false; 
            box.enabled = false;
            coinManager?.RegisterCollection(this.gameObject);
        }
        else
        {
            spriteRenderer.enabled = false;
            box.enabled = false;
            skillButton.SetButtonInteractable(true);
        }
    }

    public void TurnedON()
    {
        spriteRenderer.enabled = true;
        box.enabled = true;
    }

    //IEnumerator DelayDisapear()
    //{
    //    yield return new WaitForSeconds(Delay);
    //    box.enabled = true;
    //    spriteRenderer.enabled = true;
    //}


    private bool IsPlayer(GameObject obj)
    {
        return PlayerLayer == (PlayerLayer | (1 << obj.layer));
    }
}
