using UnityEngine;

public class TurnOnCanvas : MonoBehaviour
{
    public GameObject SettingsObject;
    public bool SettingsOn;

    public void CanvasOn(GameObject SettingsObject)
    {
        SettingsOn = !SettingsOn;
        if (SettingsOn)
        {
            SettingsObject.SetActive(true);
        }
        else
        {
            SettingsObject.SetActive(false);
        }
    }
}
