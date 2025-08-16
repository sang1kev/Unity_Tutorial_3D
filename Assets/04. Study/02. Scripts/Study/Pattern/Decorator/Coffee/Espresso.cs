using UnityEngine;

public class Espresso : ICoffee
{
    public string Description()
    {
        return "Espresso";
    }

    public int Cost()
    {
        return 4000;
    }
}