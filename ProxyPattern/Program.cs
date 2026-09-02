using System;

namespace ProxyPattern
{
    public interface IImage
    {
        void Display();
    }

    public class RealImage : IImage
    {
        private readonly string fileName;

        public RealImage(string fileName)
        {
            this.fileName = fileName;
            LoadFromDisk();
        }

        private void LoadFromDisk()
        {
            Console.WriteLine($"Loading {fileName} from disk...");
        }

        public void Display()
        {
            Console.WriteLine($"Displaying {fileName}");
        }
    }

    public class ProxyImage : IImage
    {
        private readonly string fileName;
        private RealImage? realImage;

        public ProxyImage(string fileName)
        {
            this.fileName = fileName;
        }

        public void Display()
        {
            realImage ??= new RealImage(fileName);
            realImage.Display();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IImage image = new ProxyImage("photo.jpg");

            Console.WriteLine("Image created, but not loaded yet.");
            image.Display();
            Console.WriteLine("Second call, no reload:");
            image.Display();
        }
    }
}
