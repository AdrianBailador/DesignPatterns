using FacadePattern;

namespace DesignPatterns.Tests;

public class FacadePatternTests
{
    [Fact]
    public void MethodA_DoesNotThrow()
    {
        var facade = new Facade();
        var exception = Record.Exception(() => facade.MethodA());

        Assert.Null(exception);
    }

    [Fact]
    public void MethodB_DoesNotThrow()
    {
        var facade = new Facade();
        var exception = Record.Exception(() => facade.MethodB());

        Assert.Null(exception);
    }
}
