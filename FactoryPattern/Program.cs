using System;

namespace FactoryPattern
{
    public abstract class Animal
    {
        public abstract string Speak();
    }

    public class Dog : Animal
    {
        public override string Speak()
        {
            return "Woof!";
        }
    }

    public class Cat : Animal
    {
        public override string Speak()
        {
            return "Meow!";
        }
    }

    public class AnimalFactory
    {
        public Animal GetAnimal(string animalType)
        {
            switch (animalType)
            {
                case "Dog":
                    return new Dog();
                case "Cat":
                    return new Cat();
                default:
                    throw new Exception("Invalid animal type");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AnimalFactory factory = new AnimalFactory();
            Animal dog = factory.GetAnimal("Dog");
            Animal cat = factory.GetAnimal("Cat");

            Console.WriteLine("Dog says: " + dog.Speak());
            Console.WriteLine("Cat says: " + cat.Speak());
        }
    }
}
