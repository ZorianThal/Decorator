using System;

interface ICoffee
{
    string GetDescription();
    double GetCost();
}

class Coffee : ICoffee
{
   public string GetDescription()
    {
        return "Кофе";
    }

    public double GetCost()
    {
        return 100;
    }
}

class CoffeeDecorator : ICoffee
{
    protected ICoffee coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        this.coffee = coffee;
    }

    public virtual string GetDescription()
    {
        return coffee.GetDescription();
    }

    public virtual double GetCost()
    {
        return coffee.GetCost();
    }
}

class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee)
        : base(coffee)
    {

    }
    public override string GetDescription()
    {
        return coffee.GetDescription() + ", сахар";
    }

    public override double GetCost()
    {
        return coffee.GetCost() + 10;
    }
}

class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee)
        : base(coffee)
    {
    }
    public override string GetDescription()
    {
        return coffee.GetDescription() + ", молоко";
    }

    public override double GetCost()
    {
        return coffee.GetCost() + 30;
    }
}

class Program
{
    static void Main()
    {
        ICoffee coffee = new Coffee();

        coffee = new MilkDecorator(coffee);
        coffee = new SugarDecorator(coffee);

        Console.WriteLine(coffee.GetDescription());
        Console.WriteLine("Цена - " + coffee.GetCost());
    }
}