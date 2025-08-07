using UnityEngine;
using UnityEngine.UI;

public class StudyLambda : MonoBehaviour
{
    public delegate void MyDelegate(string s);
    public MyDelegate myDelegate;

    public Button button;

    void Start()
    {
        // 버튼에 1개의 기능을 등록하는 방법
        button.onClick.AddListener(ButtonEvent);
        // button.onClick.AddListener(OnLog("Hello")); // 사용 X
        
        // 익명함수로 여러 기능을 등록하는 방법
        button.onClick.AddListener(delegate
        {
            ButtonEvent();
            OnLog("Lambda");
        });

        // 람다식으로 1개의 기능을 등록하는 방법
        button.onClick.AddListener(() => OnLog("Hello"));
        
        // 람다식으로 여러 기능을 등록하는 방법
        button.onClick.AddListener(() =>
        {
            ButtonEvent();
            OnLog("Lambda");
        });

        myDelegate += OnLog;

        myDelegate += str => OnLog(str);

        myDelegate?.Invoke("Lambda");
    }

    private void ButtonEvent()
    {
        Debug.Log("Button Event");
    }
    
    private void OnLog(string msg)
    {
        Debug.Log(msg);
    }
}