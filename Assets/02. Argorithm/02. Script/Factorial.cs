using UnityEngine;

public class Factorial : MonoBehaviour
{
    public int num = 10;

    void Start()
    {
        for (int i = 0; i < num; i++)
        {
            int result = FactorialMethod(i);
            Debug.Log(result);
        }
    }

    // Update is called once per frame
    private int FactorialMethod(int n)
    {
        if (n == 0)
        {
            return 1;
        }
        else
        {
            return n * FactorialMethod(n-1);
        }
    }
}
