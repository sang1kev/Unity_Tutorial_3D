using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;
using UnityEngine.UI;

public class StudyUnityAction : MonoBehaviour
{
    public UnityAction unityAction;
    public Button button;

    public int score;

    void Start()
    {
        unityAction += MethodA;
        unityAction += MethodA;
        unityAction += MethodA;

        button.onClick.AddListener(unityAction);

        button.onClick.AddListener(() =>
        {
            Debug.Log("Hello");
            MethodA();
        });
        
        score = GetScore();
    }

    private void MethodA()
    {
        Debug.Log("Method A");
    }

    public void GetScore2()
    {
        score = 10;
    }

    private int GetScore()
    {
        int score = 10;
        return score;
    }
}