using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private InfoHolder infoHolder;
    private GameObject infoHolderObject;

    public void Start()
    {
        infoHolderObject = GameObject.Find("InfoHolder");
        infoHolder = infoHolderObject.GetComponent<InfoHolder>();
    }


    public void UpdateCurrLevel(int level)
    {
        infoHolder.CurrentLevel = level;
        Debug.Log($"Current Level: {level}");
    }
}
