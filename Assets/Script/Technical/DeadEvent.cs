using UnityEngine;

public class DeadEvent : MonoBehaviour
{
    public bool IsOpen;
    public void TurnCanvasOn(GameObject SettingsObject)
    {
        IsOpen = !IsOpen;
        if (IsOpen)
        {
            SettingsObject.SetActive(true);
        }
        else
        {
            SettingsObject.SetActive(false);
        }
    }
}
