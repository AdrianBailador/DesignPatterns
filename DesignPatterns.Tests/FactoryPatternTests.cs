using FactoryPattern;

namespace DesignPatterns.Tests;

public class FactoryPatternTests
{
    [Fact]
    public void GetAnimal_Dog_ReturnsDogThatWoofs()
    {
        var factory = new AnimalFactory();
        Animal animal = factory.GetAnimal("Dog");

        Assert.IsType<Dog>(animal);
        Assert.Equal("Woof!", animal.Speak());
    }

    [Fact]
    public void GetAnimal_Cat_ReturnsCatThatMeows()
    {
        var factory = new AnimalFactory();
        Animal animal = factory.GetAnimal("Cat");

        Assert.IsType<Cat>(animal);
        Assert.Equal("Meow!", animal.Speak());
    }

    [Fact]
    public void GetAnimal_UnknownType_ThrowsArgumentException()
    {
        var factory = new AnimalFactory();
        Assert.Throws<ArgumentException>(() => factory.GetAnimal("Fish"));
    }
}
