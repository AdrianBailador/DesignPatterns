using System;
using System.Collections.Generic;

namespace CommandPattern
{
    public interface ICommand
    {
        void Execute();
    }

    public class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Receiver Action");
        }
    }

    public class ConcreteCommand : ICommand
    {
        private Receiver receiver;

        public ConcreteCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void Execute()
        {
            receiver.Action();
        }
    }

    public class Invoker
    {
        private ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            ICommand command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
    }
}
