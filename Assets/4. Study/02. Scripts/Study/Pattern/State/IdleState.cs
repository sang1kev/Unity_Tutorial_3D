using System.Collections;
using UnityEngine;

public class IdleState : MonoBehaviour, IState
{
    public void StateEnter()
    {
        Debug.Log("Enter Idle");
        StartCoroutine(MethodA());
    }

    public void StateUpdate()
    {
        Debug.Log("Update Idle");
    }

    public void StateExit()
    {
        Debug.Log("Exit Idle");
    }
    
    IEnumerator MethodA()
    {
        yield return null;
    }
}