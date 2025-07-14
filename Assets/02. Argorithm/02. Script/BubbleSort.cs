using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    void Start()
    {
        Debug.Log($"정렬 전 : " + string.Join(", ", array));

        Bubble(array);
        Debug.Log($"정렬 전 : " + string.Join(", ", array));
    }

    private void Bubble(int[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}
