using UnityEngine;

public class PlayerScoreManager : MonoBehaviour
{
    //NON JSON FILE 
    public int Score;
    public string Time;
    public int Level;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private InfoHolder infoHolder;
    private GameObject infoHolderObject;

    private void Start()
    {
        infoHolderObject = GameObject.Find("InfoHolder");
        infoHolder = infoHolderObject.GetComponent<InfoHolder>();
    }


    public void UpdateScore(int score, string time)
    {
        Score = score;
        Time = time;
        Level = infoHolder.CurrentLevel;
        Debug.Log(Score);
        Debug.Log(Time);
    }

    public void AddScore()
    {

    }

}
