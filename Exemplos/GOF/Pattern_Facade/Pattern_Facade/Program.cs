using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Facade
{

    public class Cliente
    {
        public string Nome { get; set; }
        public Cliente(string nome)
        {
            Nome = nome;
        }
    }

    public class LimiteCredito
    {
        public bool PossuiLimiteCredito(Cliente cliente, double valor)
        {
            Console.WriteLine("Verificando o limite de crédito do cliente " + cliente.Nome);
            if (valor > 200000.00)
                return false;
            else
                return true;
        }
    }

    public class Serasa
    {
        public bool EstaNoSerasa(Cliente cliente)
        {
            Console.WriteLine("Verificando SERASA do cliente " + cliente.Nome);
            return false;
        }
    }

    public class Cadin
    {
        public bool EstaNoCadin(Cliente cliente)
        {
            Console.WriteLine("Verificando o CADIN para o cliente " + cliente.Nome);
            return false;
        }
    }

    public class Facade
    {
        private LimiteCredito limite = new LimiteCredito();
        private Serasa serasa = new Serasa();
        private Cadin cadin = new Cadin();

        public string ConcederEmprestimo(Cliente cliente, double valor)
        {
            var retorno = "";

            if (!limite.PossuiLimiteCredito(cliente, valor))
                retorno = string.Format("O Cliente {0} não possui saldo para {1:C}\n ", cliente.Nome, valor);

            if (serasa.EstaNoSerasa(cliente))
                retorno = retorno + "Cliente " + cliente.Nome + " possui restrição no SERASA";

            if (cadin.EstaNoCadin(cliente))
                retorno = retorno + "Cliente " + cliente.Nome + " possui restrição no CADIN";

            return "";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Cria uma instância do Facade
            Facade concedeCredito = new Facade();

            // Cria uma instância de um  novo Cliente informando o nome
            Cliente cliente1 = new Cliente("João");
            double valor = 199000.00;

            Console.WriteLine("{0} saque no valor de {1:C}\n", cliente1.Nome, valor);
            //Utiliza o Facade para verificar condições de concessão ou não
            string resultado = concedeCredito.ConcederEmprestimo(cliente1, valor);

            //exibe o resultado
            if (resultado == "")
                Console.WriteLine("O empréstimo pleiteado pelo cliente " + cliente1.Nome + " foi Aprovado");
            else
                Console.WriteLine("O empréstimo pleiteado pelo cliente foi Negado devido a:\n" + resultado);

            Console.ReadKey();
        }
    }
}
