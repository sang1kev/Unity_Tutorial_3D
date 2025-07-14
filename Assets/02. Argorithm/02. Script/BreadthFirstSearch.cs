using System.Collections.Generic;
using UnityEngine;

public class BreadthFirstSearch : MonoBehaviour
{
    public Queue<int> queue = new Queue<int>();
    private int[,] nodes = new int[8, 8]
    {
        { 0, 1, 1, 1, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 1, 1, 0, 0 },
        { 1, 0, 0, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 0, 0, 1, 0 },
        { 0, 1, 0, 0, 0, 1, 0, 0 },
        { 0, 1, 0, 0, 1, 0, 0, 1 },
        { 0, 0, 0, 1, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 1, 0, 0 }
    };

    private bool[] visited = new bool[8];

    void Start()
    {
        DFSearch(0);
    }

    private void DFSearch(int start)
    {
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int index = queue.Dequeue();

            if (!visited[index])
            {
                visited[index] = true;
                Debug.Log($"{index}번 노드에 방문");
                 
                for (int i = 0; i < nodes.GetLength(0); i++)
                {
                    if (nodes[index, i] == 1 && !visited[i])
                    {
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}
