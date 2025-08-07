using UnityEngine;

public class JumpState : MonoBehaviour, IState
{
    public void StateEnter()
    {
        Debug.Log("Enter Jump");
    }

    public void StateUpdate()
    {
        Debug.Log("Update Jump");
    }

    public void StateExit()
    {
        Debug.Log("Exit Jump");
    }
}