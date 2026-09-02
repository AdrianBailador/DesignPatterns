using System;

namespace PrototypePattern
{
    public abstract class Shape
    {
        public string Color { get; set; } = string.Empty;

        public abstract Shape Clone();
    }

    public class Circle : Shape
    {
        public int Radius { get; set; }

        public override Shape Clone()
        {
            return new Circle { Color = Color, Radius = Radius };
        }

        public override string ToString() => $"Circle(Color={Color}, Radius={Radius})";
    }

    public class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override Shape Clone()
        {
            return new Rectangle { Color = Color, Width = Width, Height = Height };
        }

        public override string ToString() => $"Rectangle(Color={Color}, Width={Width}, Height={Height})";
    }

    class Program
    {
        static void Main(string[] args)
        {
            var original = new Circle { Color = "Red", Radius = 10 };
            var clone = (Circle)original.Clone();
            clone.Color = "Blue";

            Console.WriteLine($"Original: {original}");
            Console.WriteLine($"Clone: {clone}");
        }
    }
}
