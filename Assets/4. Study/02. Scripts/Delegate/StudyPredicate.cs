using System;
using UnityEngine;

public class StudyPredicate : MonoBehaviour
{
    public Predicate<int> myPredicate;
    
    public int level = 10;

    void Start()
    {
        myPredicate = n => n <= 10;
        string msg = myPredicate(level) ? "초보자 사냥터 입장 가능" : "초보자 사냥터 입장 불가능";
        Debug.Log(msg);
    }
}