using SingletonPattern;

namespace DesignPatterns.Tests;

public class SingletonPatternTests
{
    [Fact]
    public void Instance_AlwaysReturnsTheSameObject()
    {
        Singleton first = Singleton.Instance;
        Singleton second = Singleton.Instance;

        Assert.Same(first, second);
    }
}
