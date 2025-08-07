using UnityEngine;
using UnityEngine.Events;

public class StudyUnityEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent onUnityEvent;

    void Start()
    {
        // onUnityEvent += MethodA;
        onUnityEvent.AddListener(MethodA);
        onUnityEvent.RemoveListener(MethodA);
        
        onUnityEvent.RemoveAllListeners();
        

        // onUnityEvent.AddListener(delegate
        // {
        //     Debug.Log("Hello");
        //     Debug.Log("Unity");
        //     Debug.Log("World");
        //     MethodA();
        //     MethodB();
        //
        //     PrintLog("Hello Unity");
        // });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onUnityEvent?.Invoke();
        }
    }

    private void MethodA()
    {
        Debug.Log("Method A");
    }
    
    private void MethodB()
    {
        Debug.Log("Method B");
    }

    private void PrintLog(string msg)
    {
        Debug.Log(msg);
    }
}