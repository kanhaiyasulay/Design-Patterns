using System;
namespace CoffeeShop
{
    // Abstract Base Class for Beverages
    public abstract class Beverage
    {
        private string privateDesc; // Private field to hold the value

                // Mark Description as virtual so it can be overridden
        public virtual string Description
        {
            get { return privateDesc; } 
            protected set { privateDesc = value; }
        }

        // Constructor to set the default description
        public Beverage()
        {
            Description = "Unknown Beverage";
        }

        // Abstract method for cost, to be implemented by derived classes
        public abstract double Cost();
    }

    // Concrete Components
    public class Espresso : Beverage
    {
        public Espresso()
        {
            Description = "Espresso";
        }

        public override double Cost()
        {
            return 1.99;
        }
    }

    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            Description = "House Blend Coffee";
        }

        public override double Cost() => 0.89;
    }

    // Abstract Decorator Class
    public abstract class CondimentDecorator : Beverage
    {
        protected Beverage beverage;

        public CondimentDecorator(Beverage beverage)
        {
            this.beverage = beverage;
        }

        // Override the Description property
        public override string Description => beverage.Description;
    }

    // Concrete Decorators
    public class Milk : CondimentDecorator
    {
/*U are telling that =>  Hey, the 'Beverage beverage' parameter I received in the Child
 class should also be passed to the Beverage (base) class constructor */
        public Milk(Beverage beverage) : base(beverage) { }

        public override string Description => beverage.Description + ", Milk";

        public override double Cost()
        {
            return beverage.Cost() + 0.10;
        }
    }

    public class Mocha : CondimentDecorator
    {
        public Mocha(Beverage beverage) : base(beverage) { }

        public override string Description => beverage.Description + ", Mocha";

        public override double Cost()
        {
            return beverage.Cost() + 0.20;
        }
    }

    public class Soy : CondimentDecorator
    {
        public Soy(Beverage beverage) : base(beverage) { }

        public override string Description => beverage.Description + ", Soy";

        public override double Cost()
        {
            return beverage.Cost() + 0.15;
        }
    }

    public class Whip : CondimentDecorator
    {
        public Whip(Beverage beverage) : base(beverage) { }

        public override string Description => beverage.Description + ", Whip";

        public override double Cost()
        {
            return beverage.Cost() + 0.10;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Order an Espresso
            Beverage beverage = new Espresso();
            Console.WriteLine($"{beverage.Description} ${beverage.Cost():0.00}");

            // Order a HouseBlend with Soy, Mocha, and Whip
            Beverage beverage2 = new HouseBlend();
            beverage2 = new Soy(beverage2);
            beverage2 = new Mocha(beverage2);
            beverage2 = new Whip(beverage2);
            Console.WriteLine($"{beverage2.Description} ${beverage2.Cost():0.00}");
        }
    }
}

