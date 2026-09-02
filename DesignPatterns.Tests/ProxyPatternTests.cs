using ProxyPattern;

namespace DesignPatterns.Tests;

public class ProxyPatternTests
{
    [Fact]
    public void Display_BeforeFirstCall_HasNotLoadedTheRealImage()
    {
        var originalOut = Console.Out;
        try
        {
            using var writer = new StringWriter();
            Console.SetOut(writer);

            IImage image = new ProxyImage("photo.jpg");

            Assert.DoesNotContain("Loading", writer.ToString());
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }

    [Fact]
    public void Display_CalledTwice_OnlyLoadsTheRealImageOnce()
    {
        var originalOut = Console.Out;
        try
        {
            using var writer = new StringWriter();
            Console.SetOut(writer);

            IImage image = new ProxyImage("photo.jpg");
            image.Display();
            image.Display();

            string output = writer.ToString();
            int loadCount = output.Split("Loading").Length - 1;
            Assert.Equal(1, loadCount);
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }
}
