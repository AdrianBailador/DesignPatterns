using PrototypePattern;

namespace DesignPatterns.Tests;

public class PrototypePatternTests
{
    [Fact]
    public void Clone_ProducesADistinctObjectWithSameValues()
    {
        var original = new Circle { Color = "Red", Radius = 10 };
        var clone = (Circle)original.Clone();

        Assert.NotSame(original, clone);
        Assert.Equal(original.Color, clone.Color);
        Assert.Equal(original.Radius, clone.Radius);
    }

    [Fact]
    public void Clone_MutatingTheClone_DoesNotAffectTheOriginal()
    {
        var original = new Circle { Color = "Red", Radius = 10 };
        var clone = (Circle)original.Clone();

        clone.Color = "Blue";

        Assert.Equal("Red", original.Color);
        Assert.Equal("Blue", clone.Color);
    }
}
