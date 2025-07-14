using System;
using UnityEngine;

public class InsertionSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    void Start()
    {
        Debug.Log($"정렬 전 : " + string.Join(", ", array));

        Insertion(array);
        Debug.Log($"정렬 전 : " + string.Join(", ", array));
    }

    private void Insertion(int[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n; i++)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = key;
        }
    }
}
