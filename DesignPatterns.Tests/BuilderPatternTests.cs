using BuilderPattern;

namespace DesignPatterns.Tests;

public class BuilderPatternTests
{
    [Fact]
    public void Build_ChainedCalls_ProduceConfiguredCar()
    {
        Car car = new CarBuilder().SetMake("Audi").SetModel("Q7").SetYear(2024).Build();

        Assert.Equal("Audi", car.Make);
        Assert.Equal("Q7", car.Model);
        Assert.Equal(2024, car.Year);
    }

    [Fact]
    public void Build_WithoutSettingFields_UsesDefaults()
    {
        Car car = new CarBuilder().Build();

        Assert.Equal(string.Empty, car.Make);
        Assert.Equal(string.Empty, car.Model);
        Assert.Equal(0, car.Year);
    }
}
