using System;
using UnityEngine;

public class StudyAction2 : MonoBehaviour
{
    public static event Action action;

    private void MethodA()
    {
        Debug.Log("Method A");
    }
}