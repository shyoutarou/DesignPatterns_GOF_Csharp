using Pattern_Factory.Factories;
using Pattern_Factory.Interface;
using System;

namespace Pattern_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            string linha;
            AloFactory factory = new AloFactory();
            Console.WriteLine("Digite OK para sair");
            do
            {
                Console.Write("Digite uma lingua(en/sp/de): ");
                linha = Console.ReadLine();
                IAloMundo lingua = factory.CriaAloMundo(linha);
                lingua.falaAlo();
            } while (linha != "OK");

            Console.ReadKey();
        }
    }
}
