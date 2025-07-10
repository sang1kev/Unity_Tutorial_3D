using UnityEngine;

public class Fibonacci : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            int result = FibonacciMethod(i);
            Debug.Log($"{result}");
        }
    }

    private int FibonacciMethod(int n)
    {
        if (n <= 1)
            return n;

        return FibonacciMethod(n-1) + FibonacciMethod(n-2);
    }
}
