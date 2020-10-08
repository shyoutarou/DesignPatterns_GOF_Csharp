using Pattern_AbstractFactory2.Factories;
using Pattern_AbstractFactory2.Interface;
using System;

namespace Pattern_AbstractFactory2
{
    class Program
    {
        static void Main(string[] args)
        {
            string linha;
            ConcreteFactory factory = new ConcreteFactory();
            Console.WriteLine("Digite OK para sair");
            do
            {
                Console.Write("Digite uma opção AloMundo(alo) ou Connectar(con): ");
                linha = Console.ReadLine();

                if (linha == "alo")
                {
                    Console.Write("Digite uma lingua(en/sp/de): ");
                    linha = Console.ReadLine();
                    IAloMundo lingua = factory.CriaAloMundo(linha);
                    lingua.falaAlo();

                    IConnection conexao = factory.CriaConnection("my");
                    conexao.FunctionB(lingua);
                    Console.WriteLine(conexao.conectar());
                }
                else
                {
                    Console.Write("Digite uma conexão(my/or/ss): ");
                    linha = Console.ReadLine();
                    IConnection conexao = factory.CriaConnection(linha);
                    Console.WriteLine(conexao.conectar());
                }

            } while (linha != "OK" && linha != "alo" && linha != "con");

            Console.ReadKey();
        }
    }
}
