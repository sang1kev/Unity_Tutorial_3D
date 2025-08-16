using UnityEngine;

public class Latte : ICoffee
{
    public string Description()
    {
        return "Latte";
    }

    public int Cost()
    {
        return 5500;
    }
}