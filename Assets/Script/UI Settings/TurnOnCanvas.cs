using UnityEngine;

public class TurnOnCanvas : MonoBehaviour
{
    public GameObject SettingsObject;
    public bool SettingsOn;

    private void Start()
    {
        SettingsObject.SetActive(false);
    }

    public void CanvasOn()
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
