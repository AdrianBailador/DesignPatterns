using ChainOfResponsibilityPattern;

namespace DesignPatterns.Tests;

public class ChainOfResponsibilityPatternTests
{
    private static Level1Support BuildChain()
    {
        var level1 = new Level1Support();
        var level2 = new Level2Support();
        var level3 = new Level3Support();

        level1.SetNext(level2).SetNext(level3);
        return level1;
    }

    [Theory]
    [InlineData(1, "Level1Support handled the request.")]
    [InlineData(2, "Level2Support handled the request.")]
    [InlineData(3, "Level3Support handled the request.")]
    [InlineData(99, "Level3Support handled the request.")]
    public void Handle_EscalatesToTheRightLevel(int severity, string expectedHandler)
    {
        Level1Support chain = BuildChain();
        Assert.Equal(expectedHandler, chain.Handle(severity));
    }
}
