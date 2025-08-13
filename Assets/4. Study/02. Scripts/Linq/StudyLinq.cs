using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StudyLinq : MonoBehaviour
{
    public int[] numbers = { 1, 2, 3, 4, 5 };

    void Start()
    {
        var result = from number in numbers
                     select number * number;
        
        // var result = numbers.Select(n => n * n);
        
        foreach (var n in result)
            Debug.Log(n);
    }
}