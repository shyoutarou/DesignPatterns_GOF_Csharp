using Pattern_BuilderFactory.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_BuilderFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            string linha;
            CarrosFactory factory = new CarrosFactory();
            Console.WriteLine("Digite OK para sair");
            do
            {
                Console.Write("Digite uma tipo(Moto/Carro): ");
                linha = Console.ReadLine();
                var carro = factory.CriaVeiculos(linha);
                carro.Veiculo.Mostra();
            } while (linha != "OK");

            Console.ReadKey();
        }
    }
}
