using UnityEngine;
using TMPro;

public class FinalScoreShow : MonoBehaviour
{
    [Header("Win Related Text")]
    [SerializeField] private TMP_Text BestTimeText;
    [SerializeField] private TMP_Text CurrTimeText;
    [SerializeField] private TMP_Text ScoreText;

    [Header("Lose Related Text")]
    [SerializeField] private TMP_Text loseScoreText;


    [SerializeField] private PlayerScoreManager playerScoreManager;
    
    public void UpdateFinalText()
    {
        BestTimeText.text = playerScoreManager.bestTime;
        CurrTimeText.text = playerScoreManager.currentTime;
        ScoreText.text = $"+ {playerScoreManager.currentScore}";
    }

    public void UpdateFinalLoseText()
    {
        loseScoreText.text = $"+ {playerScoreManager.currentScore}";
    }
}
