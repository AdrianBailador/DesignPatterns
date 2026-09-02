using System;

namespace StatePattern
{
    public interface IOrderState
    {
        string Name { get; }
        void Next(OrderContext context);
    }

    public class PendingState : IOrderState
    {
        public string Name => "Pending";

        public void Next(OrderContext context)
        {
            context.SetState(new ShippedState());
        }
    }

    public class ShippedState : IOrderState
    {
        public string Name => "Shipped";

        public void Next(OrderContext context)
        {
            context.SetState(new DeliveredState());
        }
    }

    public class DeliveredState : IOrderState
    {
        public string Name => "Delivered";

        public void Next(OrderContext context)
        {
            throw new InvalidOperationException("Order is already delivered.");
        }
    }

    public class OrderContext
    {
        public IOrderState State { get; private set; } = new PendingState();

        public void SetState(IOrderState state)
        {
            State = state;
        }

        public void Advance()
        {
            State.Next(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var order = new OrderContext();
            Console.WriteLine(order.State.Name);

            order.Advance();
            Console.WriteLine(order.State.Name);

            order.Advance();
            Console.WriteLine(order.State.Name);
        }
    }
}
