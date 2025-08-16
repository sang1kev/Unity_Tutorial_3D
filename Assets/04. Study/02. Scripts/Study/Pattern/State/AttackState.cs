using UnityEngine;

public class AttackState : MonoBehaviour, IState
{
    public void StateEnter()
    {
        Debug.Log("Enter Attack");
    }

    public void StateUpdate()
    {
        Debug.Log("Update Attack");
    }

    public void StateExit()
    {
        Debug.Log("Exit Attack");
    }
}