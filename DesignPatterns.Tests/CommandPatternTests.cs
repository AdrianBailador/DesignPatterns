using CommandPattern;

namespace DesignPatterns.Tests;

public class CommandPatternTests
{
    [Fact]
    public void ExecuteCommand_WithCommandSet_DoesNotThrow()
    {
        var invoker = new Invoker();
        invoker.SetCommand(new ConcreteCommand(new Receiver()));

        var exception = Record.Exception(() => invoker.ExecuteCommand());

        Assert.Null(exception);
    }

    [Fact]
    public void ExecuteCommand_WithoutCommandSet_ThrowsInvalidOperationException()
    {
        var invoker = new Invoker();

        Assert.Throws<InvalidOperationException>(() => invoker.ExecuteCommand());
    }
}
