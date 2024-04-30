using System;

namespace StrategyPattern
{
    public interface IStrategy
    {
        int DoOperation(int num1, int num2);
    }

    public class OperationAdd : IStrategy
    {
        public int DoOperation(int num1, int num2)
        {
            return num1 + num2;
        }
    }

    public class OperationSubstract : IStrategy
    {
        public int DoOperation(int num1, int num2)
        {
            return num1 - num2;
        }
    }

    public class OperationMultiply : IStrategy
    {
        public int DoOperation(int num1, int num2)
        {
            return num1 * num2;
        }
    }

    public class Context
    {
        private IStrategy strategy;

        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public int ExecuteStrategy(int num1, int num2)
        {
            return strategy.DoOperation(num1, num2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context(new OperationAdd());
            Console.WriteLine("5 + 3 = " + context.ExecuteStrategy(5, 3));

            context = new Context(new OperationSubstract());
            Console.WriteLine("5 - 3 = " + context.ExecuteStrategy(5, 3));

            context = new Context(new OperationMultiply());
            Console.WriteLine("5 * 3 = " + context.ExecuteStrategy(5, 3));
        }
    }
}
