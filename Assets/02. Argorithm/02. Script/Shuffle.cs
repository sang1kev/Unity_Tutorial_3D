using UnityEngine;

public class Shuffle : MonoBehaviour
{
    public int[] array = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    public int shuffleNum = 100;

    void Start()
    {
        ShuffleMethod();
    }

    public void ShuffleMethod()
    {
        for (int i = 0; i < shuffleNum; i++)
        {
            int randInt1 = Random.Range(0, array.Length + 1);
            int randInt2 = Random.Range(0, array.Length + 1);

            Swap(randInt1, randInt2);
        }
    }

    public void Swap(int i, int j)
    {
        var temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
