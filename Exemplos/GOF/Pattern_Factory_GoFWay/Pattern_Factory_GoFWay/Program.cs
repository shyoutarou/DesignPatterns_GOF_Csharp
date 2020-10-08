using Pattern_Factory_GoFWay.Factories;
using Pattern_Factory_GoFWay.Interface;
using System;

namespace Pattern_Factory_GoFWay
{
    class Program
    {
        static void Main(string[] args)
        {
            SecureFactory factory = new SecureFactory();
            IConnection connection = factory.createConnection("Oracle");
            Console.WriteLine("You’re connecting with " + connection.description());
            Console.ReadKey();
        }
    }
}
