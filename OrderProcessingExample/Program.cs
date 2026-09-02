using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OrderProcessingExample
{
    // ---- Domain ----

    public class OrderItem
    {
        public string Name { get; }
        public decimal Price { get; }
        public int Quantity { get; }

        public OrderItem(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public decimal Subtotal => Price * Quantity;
    }

    public class Order
    {
        public string Customer { get; }
        public IReadOnlyList<OrderItem> Items { get; }

        public Order(string customer, IReadOnlyList<OrderItem> items)
        {
            Customer = customer;
            Items = items;
        }

        public decimal Subtotal => Items.Sum(item => item.Subtotal);
    }

    // ---- Builder: assembles an Order from a fluent chain of calls ----

    public class OrderBuilder
    {
        private string customer = string.Empty;
        private readonly List<OrderItem> items = new();

        public OrderBuilder ForCustomer(string customer)
        {
            this.customer = customer;
            return this;
        }

        public OrderBuilder AddItem(string name, decimal price, int quantity)
        {
            items.Add(new OrderItem(name, price, quantity));
            return this;
        }

        public Order Build()
        {
            if (items.Count == 0) throw new InvalidOperationException("An order needs at least one item.");
            return new Order(customer, items);
        }
    }

    // ---- Strategy: interchangeable ways to turn a subtotal into a total ----

    public interface IDiscountStrategy
    {
        decimal Apply(decimal subtotal);
    }

    public class NoDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal subtotal) => subtotal;
    }

    public class PercentageDiscount : IDiscountStrategy
    {
        private readonly decimal percentage;

        public PercentageDiscount(decimal percentage)
        {
            this.percentage = percentage;
        }

        public decimal Apply(decimal subtotal) => subtotal - subtotal * percentage / 100m;
    }

    public class FixedAmountDiscount : IDiscountStrategy
    {
        private readonly decimal amount;

        public FixedAmountDiscount(decimal amount)
        {
            this.amount = amount;
        }

        public decimal Apply(decimal subtotal) => Math.Max(0, subtotal - amount);
    }

    // ---- Observer: reactions to a placed order, decoupled from placing it ----

    public interface IOrderObserver
    {
        void OnOrderPlaced(Order order, decimal total);
    }

    public class EmailNotifier : IOrderObserver
    {
        public void OnOrderPlaced(Order order, decimal total)
        {
            Console.WriteLine($"[Email] Sent confirmation to {order.Customer} for ${total.ToString("F2", CultureInfo.InvariantCulture)}.");
        }
    }

    public class InventoryUpdater : IOrderObserver
    {
        public void OnOrderPlaced(Order order, decimal total)
        {
            foreach (OrderItem item in order.Items)
            {
                Console.WriteLine($"[Inventory] Reserved {item.Quantity}x {item.Name}.");
            }
        }
    }

    public class AuditLogger : IOrderObserver
    {
        public void OnOrderPlaced(Order order, decimal total)
        {
            Console.WriteLine($"[Audit] Order for {order.Customer} placed at ${total.ToString("F2", CultureInfo.InvariantCulture)}.");
        }
    }

    // ---- Puts Strategy and Observer to work on a Builder-assembled Order ----

    public class OrderProcessor
    {
        private readonly List<IOrderObserver> observers = new();
        private readonly IDiscountStrategy discountStrategy;

        public OrderProcessor(IDiscountStrategy discountStrategy)
        {
            this.discountStrategy = discountStrategy;
        }

        public void Subscribe(IOrderObserver observer) => observers.Add(observer);

        public decimal Place(Order order)
        {
            decimal total = discountStrategy.Apply(order.Subtotal);

            foreach (IOrderObserver observer in observers)
            {
                observer.OnOrderPlaced(order, total);
            }

            return total;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Order order = new OrderBuilder()
                .ForCustomer("Adrian")
                .AddItem("Keyboard", 75, 1)
                .AddItem("Mouse", 25, 2)
                .Build();

            var processor = new OrderProcessor(new PercentageDiscount(10));
            processor.Subscribe(new EmailNotifier());
            processor.Subscribe(new InventoryUpdater());
            processor.Subscribe(new AuditLogger());

            decimal total = processor.Place(order);

            Console.WriteLine($"\nOrder total: ${total.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}
