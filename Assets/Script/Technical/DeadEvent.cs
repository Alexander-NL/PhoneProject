using System.Collections;
using UnityEngine;

public class DeadEvent : MonoBehaviour
{
    public bool IsOpen;
    public float Delay;

    public void ResetCanvas(GameObject SettingsObject)
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

    public void TurnCanvasOn(GameObject SettingsObject)
    {
        IsOpen = !IsOpen;
        if (IsOpen)
        {
            StartCoroutine(DelayApear(SettingsObject));
        }
        else
        {
            StartCoroutine(DelayDisapear(SettingsObject));
        }
    }

    IEnumerator DelayApear(GameObject SettingsObject)
    {
        yield return new WaitForSeconds(Delay);
        SettingsObject.SetActive(true);
    }

    IEnumerator DelayDisapear(GameObject SettingsObject)
    {
        yield return new WaitForSeconds(Delay);
        SettingsObject.SetActive(false);
    }
}
