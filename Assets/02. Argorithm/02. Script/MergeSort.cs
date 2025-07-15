using System;
using UnityEngine;

public class MergeSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    void Start()
    {
        Debug.Log($"정렬 전 : " + string.Join(", ", array));

        MSort(array, 0, array.Length - 1);
        Debug.Log($"정렬 전 : " + string.Join(", ", array));
    }

    private void MSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            MSort(array, left, mid);
            MSort(array, mid + 1, right);
            Merge(array, left, mid, right);
        }
    }

    private void Merge(int[] array, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] leftArr = new int[n1];
        int[] rightArr = new int[n2]; 

        for (int i = 0;  i < n1; i++)
        {
            leftArr[i] = array[left + i];
        }

        for (int i = 0; i < n2; i++)
        {
            rightArr[i] = array[mid + 1 + i];
        }

        int j = left;
        int u = 0;
        int v = 0;

        while ( u < n1 && v < n2 )
        {
            if (leftArr[u] <=  rightArr[v])
            {
                array[j] = leftArr[u];
                u++;
            }
            else
            {
                array[j] = rightArr[v];
                v++;
            }
            j++;
        }

        while (u < n1)
        {
            array[j] = leftArr[u];
            u++;
            j++;
        }

        while (v < n2) 
        {
            array[j] = rightArr[v];
            v++;
            j++;
        }
    }
}
