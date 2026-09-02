using System;

namespace SingletonPattern
{
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> lazyInstance = new(() => new Singleton());

        private Singleton() { }

        public static Singleton Instance => lazyInstance.Value;

        public void SayHello()
        {
            Console.WriteLine("Hi Adri from Singleton!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singleton instance1 = Singleton.Instance;
            Singleton instance2 = Singleton.Instance;

            instance1.SayHello();
            instance2.SayHello();

            if (instance1 == instance2)
            {
                Console.WriteLine("Both instances are the same.");
            }
            else
            {
                Console.WriteLine("Instances are different.");
            }
        }
    }
}
