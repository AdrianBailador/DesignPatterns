using AdapterPattern;

namespace DesignPatterns.Tests;

public class AdapterPatternTests
{
    [Fact]
    public void Request_AdaptsSpecificRequestIntoTargetInterface()
    {
        ITarget adapter = new Adapter(new Adaptee());

        Assert.Equal("Rough estimate is 2", adapter.Request(5));
    }
}
