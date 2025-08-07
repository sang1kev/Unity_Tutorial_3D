using UnityEngine;

public class MochaDecorator : CoffeeDecorator
{
    protected ICoffee coffee;

    public MochaDecorator(ICoffee coffee) : base (coffee)
    {
        
    }

    public virtual string Description()
    {
        return coffee.Description() + "Mocha";
    }

    public virtual int Cost()
    {
        return coffee.Cost();
    }
}
