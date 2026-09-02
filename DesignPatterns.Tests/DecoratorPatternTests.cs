using DecoratorPattern;

namespace DesignPatterns.Tests;

public class DecoratorPatternTests
{
    [Fact]
    public void SimpleCoffee_HasBaseCostAndIngredients()
    {
        Coffee coffee = new SimpleCoffee();

        Assert.Equal(1, coffee.GetCost());
        Assert.Equal("Coffee", coffee.GetIngredients());
    }

    [Fact]
    public void Decorators_StackCostsAndIngredients()
    {
        Coffee coffee = new SugarCoffee(new MilkCoffee(new SimpleCoffee()));

        Assert.Equal(1.75, coffee.GetCost());
        Assert.Equal("Coffee, Milk, Sugar", coffee.GetIngredients());
    }
}
