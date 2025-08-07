using UnityEngine;

public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee)
    {
        
    }

    public virtual string Description()
    {
        return coffee.Description() + "Milk";
    }

    public virtual int Cost()
    {
        return coffee.Cost();
    }
}
