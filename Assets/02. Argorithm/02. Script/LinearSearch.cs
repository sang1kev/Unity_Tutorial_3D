using System;
using UnityEngine;

public class LinearSearch : MonoBehaviour
{
    private int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public int target = 7;

    void Start()
    {
        LSearch(array, target);
    }

    private void LSearch(int[] array, int target)
    {
        for (int i = 0;  i < array.Length; i++)
        {
            if (array[i] == target)
            {
                Debug.Log($"{target}는(은) {i}번짹에 있습니다.");
            }
        }
    }
}
