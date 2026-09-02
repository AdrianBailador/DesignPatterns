using System;

namespace ChainOfResponsibilityPattern
{
    public abstract class SupportHandler
    {
        protected SupportHandler? next;

        public SupportHandler SetNext(SupportHandler handler)
        {
            next = handler;
            return handler;
        }

        public abstract string Handle(int severity);
    }

    public class Level1Support : SupportHandler
    {
        public override string Handle(int severity)
        {
            if (severity <= 1) return "Level1Support handled the request.";
            return next != null ? next.Handle(severity) : "No handler available.";
        }
    }

    public class Level2Support : SupportHandler
    {
        public override string Handle(int severity)
        {
            if (severity <= 2) return "Level2Support handled the request.";
            return next != null ? next.Handle(severity) : "No handler available.";
        }
    }

    public class Level3Support : SupportHandler
    {
        public override string Handle(int severity)
        {
            return "Level3Support handled the request.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var level1 = new Level1Support();
            var level2 = new Level2Support();
            var level3 = new Level3Support();

            level1.SetNext(level2).SetNext(level3);

            Console.WriteLine(level1.Handle(1));
            Console.WriteLine(level1.Handle(2));
            Console.WriteLine(level1.Handle(3));
        }
    }
}
