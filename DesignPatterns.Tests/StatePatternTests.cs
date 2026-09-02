using StatePattern;

namespace DesignPatterns.Tests;

public class StatePatternTests
{
    [Fact]
    public void NewOrder_StartsPending()
    {
        var order = new OrderContext();
        Assert.Equal("Pending", order.State.Name);
    }

    [Fact]
    public void Advance_MovesThroughShippedToDelivered()
    {
        var order = new OrderContext();

        order.Advance();
        Assert.Equal("Shipped", order.State.Name);

        order.Advance();
        Assert.Equal("Delivered", order.State.Name);
    }

    [Fact]
    public void Advance_PastDelivered_ThrowsInvalidOperationException()
    {
        var order = new OrderContext();
        order.Advance();
        order.Advance();

        Assert.Throws<InvalidOperationException>(() => order.Advance());
    }
}
