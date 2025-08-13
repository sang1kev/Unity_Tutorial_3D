using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour, IObserver
{
    public ISubject subject;

    public TextMeshProUGUI scoreUI;

    void OnEnable()
    {
        subject.AddObserver(this);
    }

    void OnDisable()
    {
        subject.RemoveObserver(this);
    }
    
    public void Notify(int score)
    {
        scoreUI.text = score.ToString();
    }
}