using BridgePattern;

namespace DesignPatterns.Tests;

public class BridgePatternTests
{
    [Fact]
    public void Operation_DelegatesToImplementationA()
    {
        var abstraction = new Abstraction(new ConcreteImplementationA());

        Assert.Contains("platform A", abstraction.Operation());
    }

    [Fact]
    public void Operation_DelegatesToImplementationB()
    {
        var abstraction = new Abstraction(new ConcreteImplementationB());

        Assert.Contains("platform B", abstraction.Operation());
    }

    [Fact]
    public void Operation_SwappingImplementation_ChangesResult()
    {
        var abstraction = new Abstraction(new ConcreteImplementationA());
        string resultA = abstraction.Operation();

        abstraction = new Abstraction(new ConcreteImplementationB());
        string resultB = abstraction.Operation();

        Assert.NotEqual(resultA, resultB);
    }
}
