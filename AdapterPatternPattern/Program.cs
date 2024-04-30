using System;

namespace AdapterPattern
{
    // Existing way requests are implemented
    public class Adaptee
    {
        public double SpecificRequest(double a, double b)
        {
            return a / b;
        }
    }

    // New standard for requests
    public interface ITarget
    {
        string Request(int i);
    }

    // Implementing the new standard in terms of the old
    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        public string Request(int i)
        {
            return "Rough estimate is " + (int)Math.Round(_adaptee.SpecificRequest(i, 3));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            ITarget adapter = new Adapter(adaptee);

            Console.WriteLine(adapter.Request(5));
        }
    }
}
