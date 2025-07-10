using UnityEngine;

public class Permutation : MonoBehaviour
{
    public int[] array = new int[3] { 0, 1, 2 };

    void Start()
    {
        PermutationMethod(array, 0);
    }

    private void PermutationMethod(int[] array, int start)
    {
        if (start == array.Length)
        {
            Debug.Log(string.Join(", ", array));
            return;
        }

        for (int i = start; i < array.Length; i++)
        {
            var temp = array[start];
            array[start] = array[i];
            array[i] = temp;

            PermutationMethod(array, start + 1);

            temp = array[start];
            array[start] = array[i];
            array[i] = temp;
        }
    }
}
