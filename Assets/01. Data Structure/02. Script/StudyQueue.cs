using System.Collections.Generic;
using UnityEngine;

public class StudyQueue : MonoBehaviour
{
    public Queue<int> queue = new Queue<int>();

    void Start()
    {
        for (int i = 0; i < 10;  i++)
        {
            queue.Enqueue(i);
        }

        int output = queue.Dequeue();
        Debug.Log(output);

        Debug.Log(queue.Peek());
    }
}
