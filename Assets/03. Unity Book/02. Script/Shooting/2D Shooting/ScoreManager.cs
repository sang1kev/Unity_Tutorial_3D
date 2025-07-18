using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{

    public TextMeshProUGUI currentScoreUI;
    public TextMeshProUGUI bestScoreUI;

    private int currentScore;
    private int bestScore;
    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;

            currentScoreUI.text = "Current : " + currentScore;

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = "Best Score : " + bestScore;

                PlayerPrefs.SetInt("BestScore", bestScore);
            }
        }
    }

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

        bestScoreUI.text = "Best Score : " + bestScore;
    }
}
