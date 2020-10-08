using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pattern_Singleton
{
    public class Singleton
    {
        // 1 - Construtor privado
        private Singleton() { }

        // 2 - Atributo privado e estático do mesmo tipo da classe 
        private static Singleton _unicaInstancia;
        private static readonly object locker = new object();
        private static String _name;

        public int _valor { get; set; }
        // Outras variáveis e propriedade aqui

        // 3. Método getInstance() é o principal ponto da classe
        public static Singleton getInstance(String n)
        {
            lock (locker)
            {
                if (_unicaInstancia == null)
                {
                    _name = n;
                    _unicaInstancia = new Singleton();
                }

                return _unicaInstancia;
            }
        }
        public void ExibirValor()
        {
            Console.WriteLine(_name + ": " + _valor);
        }
        // Outros metodos aqui
    }

    public class Singleton_2
    {



        // 1 - Construtor privado
        private Singleton_2(String n) { _name = n; }
        private static String _name;

        //// 2 - Atributo privado e estático do mesmo tipo da classe 
        //private static Singleton _unicaInstancia;
        // Responsável pela criação do objeto singleton
        class CriaInstancia
        {
            internal static readonly Singleton_2 instancia = new Singleton_2("Instancia 1") { };
            //static CriaInstancia()
            //{
            //    instancia._valor = 200;
            //}
        }
        public int _valor { get; set; }
        // Outras variáveis e propriedade aqui

        // 3. Método getInstance() é o principal ponto da classe
        public static Singleton_2 getInstance()
        {
            //if (_unicaInstancia == null)
            //{
            //    _unicaInstancia = new Singleton();
            //}
            //return _unicaInstancia;
            return CriaInstancia.instancia;
        }
        public void ExibirValor()
        {
            Console.WriteLine(_name + ": " + _valor);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // 4 - chamada ClasseSingleton.getInstance().
            //Singleton singCliente1 = Singleton.getInstance("Instancia 1");
            //singCliente1._valor = 10;
            //Singleton singCliente2 = Singleton.getInstance("Instancia 2");
            ////Exibe o 10
            //singCliente2.ExibirValor();
            //singCliente2._valor = 20;
            ////Exibe o 20
            //singCliente1.ExibirValor();








            Singleton_2 singCliente3 = Singleton_2.getInstance();
            singCliente3._valor = 10;
            //Nova thread
            Thread teste = new Thread(TesteThread);
            teste.Start();
            //Exibe o 10
            teste.Join();
            //Final thread
            Singleton_2 singCliente4 = Singleton_2.getInstance();
            //Exibe o 100
            singCliente4.ExibirValor();
            singCliente4._valor = 20;
            //Exibe o 20
            singCliente3.ExibirValor();


            Console.ReadKey();

        }

        private static void TesteThread()
        {
            Console.WriteLine("Inicio Thread");
            Singleton_2 singCliente5 = Singleton_2.getInstance();
            //Exibe o 10
            singCliente5.ExibirValor();
            singCliente5._valor = 100;
            Console.WriteLine("Fim Thread");
        }
    }
}
