using System.Collections.Generic;
using UnityEngine;

public class StudyLambda2 : MonoBehaviour
{
    public List<int> intList = new List<int>();

    void Start()
    {
        for (int i = 0; i < 10; i++)
            intList.Add(i);

        intList.RemoveAll(n => n % 2 == 0); // 짝수 모두 삭제
    }
}