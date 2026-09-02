using OrderProcessingExample;

namespace DesignPatterns.Tests;

file class RecordingObserver : IOrderObserver
{
    public int CallCount { get; private set; }
    public decimal LastTotal { get; private set; }

    public void OnOrderPlaced(Order order, decimal total)
    {
        CallCount++;
        LastTotal = total;
    }
}

public class OrderProcessingExampleTests
{
    private static Order BuildSampleOrder()
    {
        return new OrderBuilder()
            .ForCustomer("Adrian")
            .AddItem("Keyboard", 75, 1)
            .AddItem("Mouse", 25, 2)
            .Build();
    }

    [Fact]
    public void OrderBuilder_Build_ComputesSubtotalFromAllItems()
    {
        Order order = BuildSampleOrder();
        Assert.Equal(125m, order.Subtotal);
    }

    [Fact]
    public void OrderBuilder_Build_WithNoItems_Throws()
    {
        var builder = new OrderBuilder().ForCustomer("Adrian");
        Assert.Throws<InvalidOperationException>(() => builder.Build());
    }

    [Fact]
    public void NoDiscount_ReturnsSubtotalUnchanged()
    {
        IDiscountStrategy strategy = new NoDiscount();
        Assert.Equal(125m, strategy.Apply(125m));
    }

    [Fact]
    public void PercentageDiscount_ReducesSubtotalByThatPercentage()
    {
        IDiscountStrategy strategy = new PercentageDiscount(10);
        Assert.Equal(112.5m, strategy.Apply(125m));
    }

    [Fact]
    public void FixedAmountDiscount_SubtractsTheAmount()
    {
        IDiscountStrategy strategy = new FixedAmountDiscount(20);
        Assert.Equal(105m, strategy.Apply(125m));
    }

    [Fact]
    public void FixedAmountDiscount_NeverGoesBelowZero()
    {
        IDiscountStrategy strategy = new FixedAmountDiscount(1000);
        Assert.Equal(0m, strategy.Apply(125m));
    }

    [Fact]
    public void Place_NotifiesEveryObserverWithTheDiscountedTotal()
    {
        Order order = BuildSampleOrder();
        var processor = new OrderProcessor(new PercentageDiscount(10));

        var first = new RecordingObserver();
        var second = new RecordingObserver();
        processor.Subscribe(first);
        processor.Subscribe(second);

        decimal total = processor.Place(order);

        Assert.Equal(112.5m, total);
        Assert.Equal(1, first.CallCount);
        Assert.Equal(1, second.CallCount);
        Assert.Equal(112.5m, first.LastTotal);
        Assert.Equal(112.5m, second.LastTotal);
    }

    [Fact]
    public void Place_WithNoObservers_StillReturnsTheTotal()
    {
        Order order = BuildSampleOrder();
        var processor = new OrderProcessor(new NoDiscount());

        Assert.Equal(125m, processor.Place(order));
    }
}
