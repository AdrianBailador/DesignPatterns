using StrategyPattern;

namespace DesignPatterns.Tests;

public class StrategyPatternTests
{
    [Fact]
    public void ExecuteStrategy_Add_ReturnsSum()
    {
        var context = new Context(new OperationAdd());
        Assert.Equal(8, context.ExecuteStrategy(5, 3));
    }

    [Fact]
    public void ExecuteStrategy_Subtract_ReturnsDifference()
    {
        var context = new Context(new OperationSubtract());
        Assert.Equal(2, context.ExecuteStrategy(5, 3));
    }

    [Fact]
    public void ExecuteStrategy_Multiply_ReturnsProduct()
    {
        var context = new Context(new OperationMultiply());
        Assert.Equal(15, context.ExecuteStrategy(5, 3));
    }
}
