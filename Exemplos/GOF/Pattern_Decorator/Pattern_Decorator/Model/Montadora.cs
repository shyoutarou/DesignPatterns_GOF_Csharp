using System;
using System.Collections;

namespace Pattern_Decorator.Model
{
    public class Veiculo
    {
        private string tipo;
        private double _preco = -1;
        private string _descricao = "Carro Abstrato.";

        // Criamos uma Hashtable para armazenar as partes do veículo atribuindo 
        // a elas uma chave. Assim podemos realizar buscas nos elementos da coleção.
        private Hashtable partes = new Hashtable();

        public virtual double Preco
        {
            get { return _preco; }
        }
        public virtual string Descricao
        {
            get { return _descricao; }
        }

        public Veiculo()
        {
            this.tipo = "Carro";
        }

        public Veiculo(string tipo)
        {
            this.tipo = tipo;
        }

        public object this[string chave]
        {
            get { return partes[chave]; }
            set { partes[chave] = value; }
        }

        public void Mostra()
        {
            Console.WriteLine("\n-----------------------------------------------------");
            Console.WriteLine("Tipo do Veículo: {0}", tipo);
            Console.WriteLine("Chassi : {0}", partes["chassi"]);
            Console.WriteLine("Motor : {0}", partes["motor"]);
            Console.WriteLine("Rodas : {0}", partes["rodas"]);
            Console.WriteLine("Portas : {0}", partes["portas"]);
            Console.Read();
        }
    }

    public class Montadora
    {
        public void Construir(BuildVeiculo construirVeiculo)
        {
            construirVeiculo.ContruirChassi();
            construirVeiculo.ConstruirRodas();
            construirVeiculo.ConstruirPortas();
            construirVeiculo.ConstruirMotor();
        }
    }
}
