using System;
using UnityEngine;

public class QuickSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    void Start()
    {
        Debug.Log($"정렬 전 : " + string.Join(", ", array));

        Quick(array, 0, array.Length - 1);
        Debug.Log($"정렬 전 : " + string.Join(", ", array));
    }

    private void Quick(int[] array, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(array, left, right);

            Quick(array, left, pivot - 1);
            Quick(array, pivot - 1, right);
        }
    }

    private int Partition(int[] array, int left, int right)
    {
        int pivot = array[right];
        int index = left - 1;

        for (int i = left; i <= right; i++)
        {
            if (array[i] < pivot)
            {
                index++;

                int temp = array[i];
                array[i] = array[index];
                array[index] = temp;
            }
        }

        int temp2 = array[index +  1];
        array[index + 1] = array[right];
        array[right] = temp2;

        return index + 1;
    }
}
