using Pattern_Builder.Builder;
using Pattern_Builder.Model;
using System;

namespace Pattern_Builder
{

    class Teste
    {
        //Variáveis Estáticas(Nível de Classe)
        //Variáveis de Instância(Nível de Objeto)
        //Métodos Privados 
        //Métodos Públicos 
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Cria a montadora com construtores de veículos
            Montadora montadora = new Montadora();

            ConstruirVeiculo cMoto = new ConstrutorMoto();
            ConstruirVeiculo cCarro = new ConstrutorCarro();

            // Construir e exibir os veículos
            montadora.Construir(cMoto);
            cMoto.Veiculo.Mostra();

            montadora.Construir(cCarro);
            cCarro.Veiculo.Mostra();

            Console.ReadKey();
        }
    }
}
