using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StudyStack : MonoBehaviour
{
    public Stack<int> stack = new Stack<int>();
    public Stack<int> stack2 = new Stack<int>();

    public int[] array1 = new int[3] { 1, 2, 3 };
    public int[] array2;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            stack.Push(i);
        }

        int output = stack.Pop();

        Debug.Log(output);
        Debug.Log(stack.Peek());

        stack2 = new Stack<int>(array1);
        array2 = stack2.ToArray();
        List<int> list = new List<int>();
        list = stack2.ToList();
    }
}
