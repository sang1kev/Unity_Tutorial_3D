using System;
using System.Collections.Generic;
using UnityEngine;

public class StudyFunc2 : MonoBehaviour
{
    public List<Func<int, int, int>> funcList = new List<Func<int, int, int>>();
    
    void Start()
    {
        funcList.Add((a, b) => a + b);
        funcList.Add((a, b) => a - b);
        funcList.Add((a, b) => a * b);
        
        foreach (var func in funcList)
        {
            int result = func(10, 20);
            Debug.Log(result);
        }
    }
}