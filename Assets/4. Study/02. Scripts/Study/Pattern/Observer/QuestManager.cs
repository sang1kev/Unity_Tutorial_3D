using UnityEngine;

public class QuestManager : MonoBehaviour, IObserver
{
    public ISubject subject;

    void OnEnable()
    {
        subject.AddObserver(this);
    }

    void OnDisable()
    {
        subject.RemoveObserver(this);
    }

    public void Notify(int num)
    {
        Debug.Log("Äù½ºÆ® ¿Ï·á");
    }
}
