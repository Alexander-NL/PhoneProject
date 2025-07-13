using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    [SerializeField] private Button targetButton;
    public bool PlayerUseSkill;
    public float duration = 3f;

    public void SetButtonInteractable(bool isInteractable)
    {
        targetButton.interactable = isInteractable;
        Debug.Log($"Button interactable: {isInteractable}");

    }

    public void ActivateSkill()
    {
        StartCoroutine(SkillDuration(duration));
    }

    IEnumerator SkillDuration(float duration)
    {
        PlayerUseSkill = true;
        yield return new WaitForSeconds(duration);
        PlayerUseSkill = false;
    }
}
