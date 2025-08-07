using UnityEngine;

public class Expresso : ICoffee
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
