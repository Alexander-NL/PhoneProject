using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    [SerializeField] private Button targetButton;
    public void SetButtonInteractable(bool isInteractable)
    {
        targetButton.interactable = isInteractable;
        Debug.Log($"Button interactable: {isInteractable}");
    }
}
