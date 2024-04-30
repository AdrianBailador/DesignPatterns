using System;

namespace BuilderPattern
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public void Display()
        {
            Console.WriteLine($"Car: {Year} {Make} {Model}");
        }
    }

    public class CarBuilder
    {
        private Car _car;

        public CarBuilder()
        {
            _car = new Car();
        }

        public CarBuilder SetMake(string make)
        {
            _car.Make = make;
            return this;
        }

        public CarBuilder SetModel(string model)
        {
            _car.Model = model;
            return this;
        }

        public CarBuilder SetYear(int year)
        {
            _car.Year = year;
            return this;
        }

        public Car Build()
        {
            return _car;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CarBuilder builder = new CarBuilder();
            Car car = builder.SetMake("Audi").SetModel("Q7").SetYear(2024).Build();

            car.Display();
        }
    }
}
