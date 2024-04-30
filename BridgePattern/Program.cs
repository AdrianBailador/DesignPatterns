using System;

namespace BridgePattern
{
    public interface IImplementation
    {
        string OperationImplementation();
    }

    public class Abstraction
    {
        protected IImplementation implementation;

        public Abstraction(IImplementation implementation)
        {
            this.implementation = implementation;
        }

        public virtual string Operation()
        {
            return "Abstract: Base operation with:\n" +
                implementation.OperationImplementation();
        }
    }

    public class ConcreteImplementationA : IImplementation
    {
        public string OperationImplementation()
        {
            return "ConcreteImplementationA: Here's the result on the platform A.";
        }
    }

    public class ConcreteImplementationB : IImplementation
    {
        public string OperationImplementation()
        {
            return "ConcreteImplementationB: Here's the result on the platform B.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Abstraction abstraction = new Abstraction(new ConcreteImplementationA());
            Console.WriteLine(abstraction.Operation());

            abstraction = new Abstraction(new ConcreteImplementationB());
            Console.WriteLine(abstraction.Operation());
        }
    }
}
