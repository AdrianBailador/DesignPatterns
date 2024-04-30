using System;

namespace DecoratorPattern
{
    public abstract class Coffee
    {
        public abstract double GetCost(); // Returns the cost of the coffee
        public abstract string GetIngredients(); // Returns the ingredients of the coffee
    }

    public class SimpleCoffee : Coffee
    {
        public override double GetCost()
        {
            return 1;
        }

        public override string GetIngredients()
        {
            return "Coffee";
        }
    }

    public class MilkCoffee : Coffee
    {
        protected Coffee coffee;

        public MilkCoffee(Coffee coffee)
        {
            this.coffee = coffee;
        }

        public override double GetCost()
        {
            return coffee.GetCost() + 0.5;
        }

        public override string GetIngredients()
        {
            return coffee.GetIngredients() + ", Milk";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Coffee simpleCoffee = new SimpleCoffee();
            Console.WriteLine("Simple Coffee:");
            Console.WriteLine("Cost: " + simpleCoffee.GetCost() + "€");
            Console.WriteLine("Ingredients: " + simpleCoffee.GetIngredients());

            Coffee milkCoffee = new MilkCoffee(simpleCoffee);
            Console.WriteLine("\nMilk Coffee:");
            Console.WriteLine("Cost: " + milkCoffee.GetCost()+ "€");
            Console.WriteLine("Ingredients: " + milkCoffee.GetIngredients() );
        }
    }
}
