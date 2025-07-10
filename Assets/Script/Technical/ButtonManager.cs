using Unity.VisualScripting;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [Header("Script Reference")]
    [SerializeField] private InfoHolder infoHolder;
    [SerializeField] private SceneChanger changer;

    [Header("Object Reference")]
    [SerializeField] GameObject UI;
    [SerializeField] GameObject UI2;

    private GameObject infoHolderObject;

    public void Start()
    {
        infoHolderObject = GameObject.Find("InfoHolder");
        infoHolder = infoHolderObject.GetComponent<InfoHolder>();
        UI.SetActive(false);
        UI2.SetActive(false);
    }


    //bikin function buat check int di button nya ama curr level klo dia pas baru nyala yg change scene
    //klo ngk muncul U
    public void TurnOff()
    {
        UI.SetActive(false);
        UI2.SetActive(false);
    }

    public void CheckUnlocked(int level)
    {
        if (level > 3)
        {
            UI2.SetActive(true);
        }
        else if (infoHolder.CurrentLevel >= level)
        {
            changer.ChangeSceneWithFade("SampleScene");
        }
        else
        {
            UI.SetActive(true);
        }
    }

    public void UpdateCurrLevel(int level)
    {
        infoHolder.CurrentLevel = level;
        Debug.Log($"Current Level: {level}");
    }
}
