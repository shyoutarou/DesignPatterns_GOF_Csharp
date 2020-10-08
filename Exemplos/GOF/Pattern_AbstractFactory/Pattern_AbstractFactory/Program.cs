using System;

namespace Pattern_AbstractFactory
{
    public interface IAbstractFactory
    {
        IAbstractProductA CreateProductA();
        IAbstractProductB CreateProductB();
    }

    // Each distinct product of a product family should have a base interface.
    // All variants of the product must implement this interface.
    public interface IAbstractProductA
    {
        string UsefulFunctionA();
    }

    // Concrete Products are created by corresponding Concrete Factories.
    class ConcreteProductA1 : IAbstractProductA
    {
        public string UsefulFunctionA(){  return "The result of the product A1."; }
    }

    class ConcreteProductA2 : IAbstractProductA
    {
        public string UsefulFunctionA() { return "The result of the product A2."; }
    }

    public interface IAbstractProductB
    {
        // Product B is able to do its own thing...
        // ...but it also can collaborate with the ProductA.
        string UsefulFunctionB();

        // The Abstract Factory makes sure that all products it creates are of
        // the same variant and thus, compatible.
        string AnotherUsefulFunctionB(IAbstractProductA collaborator);
    }

    // Concrete Products are created by corresponding Concrete Factories.
    class ConcreteProductB1 : IAbstractProductB
    {
        public string UsefulFunctionB() { return "The result of the product B1."; }

        // The variant, Product B1, is only able to work correctly with the
        // variant, Product A1. Nevertheless, it accepts any instance of
        // AbstractProductA as an argument.
        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            var result = collaborator.UsefulFunctionA();
            return $"The result of the B1 collaborating with the ({result})";
        }
    }

    class ConcreteProductB2 : IAbstractProductB
    {
        public string UsefulFunctionB() { return "The result of the product B2."; }

        // The variant, Product B2, is only able to work correctly with the
        // variant, Product A2. Nevertheless, it accepts any instance of
        // AbstractProductA as an argument.
        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            var result = collaborator.UsefulFunctionA();
            return $"The result of the B2 collaborating with the ({result})";
        }
    }


    internal class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }

    internal class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA1();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // The client code can work with any concrete factory class.
            Console.WriteLine("Client: Testing client code with the first factory type...");
            ClientMethod(new ConcreteFactory1());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the second factory type...");
            ClientMethod(new ConcreteFactory2());

            Console.ReadKey();
        }

        public static void ClientMethod(IAbstractFactory factory)
        {
            var productA = factory.CreateProductA();
            var productB = factory.CreateProductB();

            Console.WriteLine(productB.UsefulFunctionB());
            Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
        }
    }
}
