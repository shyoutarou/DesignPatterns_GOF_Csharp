using Pattern_Decorator.Builder;
using Pattern_Decorator.Decorator;
using Pattern_Decorator.Model;
using System;

namespace Pattern_Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cria a montadora com construtores de veículos
            Montadora montadora = new Montadora();

            BuildVeiculo cMoto = new ConstrutorMoto();
            BuildVeiculo cCarro = new ConstrutorCarro();

            // Construir e exibir os veículos
            montadora.Construir(cMoto);
            cMoto.Veiculo.Mostra();

            montadora.Construir(cCarro);
            cCarro.Veiculo.Mostra();




            Console.WriteLine(" --------------Carro Padrão-----------------------");
            Console.WriteLine("Descricao --> " + cCarro.Veiculo.Descricao.TrimEnd(' ', ','));
            Console.WriteLine("Preco -->" + cCarro.Veiculo.Preco.ToString());
            Console.ReadLine();

            Console.WriteLine(" --------------Carro Decorado---------------------");
            //decora o carro com banco de couro
            cCarro.Veiculo = new Carro_Couro(cCarro.Veiculo);
            Console.WriteLine("Descricao --> " + cCarro.Veiculo.Descricao.TrimEnd(' ', ','));
            Console.WriteLine("Preco -->" + cCarro.Veiculo.Preco.ToString());

            //decora o carro com motor turbo
            cCarro.Veiculo = new Carro_Turbo(cCarro.Veiculo);
            Console.WriteLine("Descricao --> " + cCarro.Veiculo.Descricao.TrimEnd(' ', ','));
            Console.WriteLine("Preco -->" + cCarro.Veiculo.Preco.ToString());
            Console.ReadLine();



            Console.ReadKey();
        }
    }
}
