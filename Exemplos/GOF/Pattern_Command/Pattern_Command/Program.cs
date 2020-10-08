using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Command
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nome { get; set; }
        public Cliente(string nome)
        {
            Nome = nome;
        }

        public void ApertarMercadoria(int horas)
        {
            if (horas > 0)
                Console.WriteLine("O Cliente apertou a mercadoria por {0}Hs.", horas);
            else
                Console.WriteLine("O Cliente não apertou a mercadoria.");
        }

        public void PedirDesconto(double reais)
        {
            if (reais > 0)
                Console.WriteLine("O Cliente pediu desconto de {0} reais.", reais);
            else if (reais == 0)
                Console.WriteLine("O Cliente não pediu desconto.");
            else
                Console.WriteLine("O Cliente deu gorjeta.");
        }

        public void ReclamarComGerente(bool reclama)
        {
            if (reclama)
                Console.WriteLine("O Cliente reclamou ao gerente.");
            else
                Console.WriteLine("O Cliente reclamou somente ao funcionário.");
        }
    }

    public abstract class ClienteCommand
    {
        protected Cliente _cliente;

        public ClienteCommand(Cliente cliente)
        {
            _cliente = cliente;
        }

        public abstract void Executar();
        public abstract void Desfazer();
    }

    class ApertarCommand : ClienteCommand
    {
        public int horas { get; set; }
        public ApertarCommand(Cliente cliente) : base(cliente) { }

        public override void Executar()
        {
            _cliente.ApertarMercadoria(horas);
        }

        public override void Desfazer()
        {
            _cliente.ApertarMercadoria(0);
        }
    }

    class PedirCommand : ClienteCommand
    {
        public double desconto { get; set; }
        public PedirCommand(Cliente cliente) : base(cliente) { }

        public override void Executar()
        {
            _cliente.PedirDesconto(desconto);
        }

        public override void Desfazer()
        {
            _cliente.PedirDesconto(-desconto);
        }
    }


    class ReclamarCommand : ClienteCommand
    {
        public bool reclamacao { get; set; }

        public ReclamarCommand(Cliente cliente) : base(cliente) { }

        public override void Executar()
        {
            _cliente.ReclamarComGerente(reclamacao);
        }

        public override void Desfazer()
        {
            _cliente.ReclamarComGerente(!reclamacao);
        }
    }

    class ClienteControle
    {
        public Queue<ClienteCommand> Comandos;
        private Stack<ClienteCommand> _desfazerPilha;

        public ClienteControle()
        {
            Comandos = new Queue<ClienteCommand>();
            _desfazerPilha = new Stack<ClienteCommand>();
        }

        public void ExecutarComandos()
        {
            Console.WriteLine("EXECUTANDO COMANDO(S).");

            while (Comandos.Count > 0)
            {
                ClienteCommand comando = Comandos.Dequeue();
                comando.Executar();
                _desfazerPilha.Push(comando);
            }
        }

        public void DesfazerComandos(int numComandosDesfazer)
        {
            Console.WriteLine("DESFAZENDO {0} COMANDO(S).", numComandosDesfazer);

            while (numComandosDesfazer > 0 && _desfazerPilha.Count > 0)
            {
                ClienteCommand comand = _desfazerPilha.Pop();
                comand.Desfazer();
                numComandosDesfazer--;
            }
        }
    }



    public class Robo
    {
        public void Mover(int ParaFrente)
        {
            if (ParaFrente > 0)
                Console.WriteLine("O Robo foi movimentado para frente {0}mm.", ParaFrente);
            else
                Console.WriteLine("O Robo foi movimentado para trás {0}mm.", -ParaFrente);
        }

        public void RotacionarParaEsquerda(double rotacionarParaEsquerda)
        {
            if (rotacionarParaEsquerda > 0)
                Console.WriteLine("O Robo foi rotacionaod para esquerda {0} degrees.", rotacionarParaEsquerda);
            else
                Console.WriteLine("O Robo foi rotacionado para direita {0} degrees.", -rotacionarParaEsquerda);
        }

        public void Escavar(bool paraCima)
        {
            if (paraCima)
                Console.WriteLine("O Robo colheu material do solo.");
            else
                Console.WriteLine("O Robo despejou o material colhido.");
        }
    }

    public abstract class RoboCommand
    {
        protected Robo _robo;

        public RoboCommand(Robo robo)
        {
            _robo = robo;
        }

        public abstract void Executar();
        public abstract void Desfazer();
    }

    class MoverCommand : RoboCommand
    {
        public int ParaFrente { get; set; }
        public MoverCommand(Robo robo) : base(robo) { }

        public override void Executar()
        {
            _robo.Mover(ParaFrente);
        }

        public override void Desfazer()
        {
            _robo.Mover(-ParaFrente);
        }
    }

    class RotacionarCommand : RoboCommand
    {
        public double rotacionarParaEsquerda { get; set; }
        public RotacionarCommand(Robo robo) : base(robo) { }

        public override void Executar()
        {
            _robo.RotacionarParaEsquerda(rotacionarParaEsquerda);
        }

        public override void Desfazer()
        {
            _robo.RotacionarParaEsquerda(-rotacionarParaEsquerda);
        }
    }


    class EscavarCommand : RoboCommand
    {
        public bool ColherMaterial { get; set; }

        public EscavarCommand(Robo robo) : base(robo) { }

        public override void Executar()
        {
            _robo.Escavar(ColherMaterial);
        }

        public override void Desfazer()
        {
            _robo.Escavar(!ColherMaterial);
        }
    }

    class RoboControle
    {
        public Queue<RoboCommand> Comandos;
        private Stack<RoboCommand> _desfazerPilha;

        public RoboControle()
        {
            Comandos = new Queue<RoboCommand>();
            _desfazerPilha = new Stack<RoboCommand>();
        }

        public void ExecutarComandos()
        {
            Console.WriteLine("EXECUTANDO COMANDO(S).");

            while (Comandos.Count > 0)
            {
                RoboCommand comando = Comandos.Dequeue();
                comando.Executar();
                _desfazerPilha.Push(comando);
            }
        }

        public void DesfazerComandos(int numComandosDesfazer)
        {
            Console.WriteLine("DESFAZENDO {0} COMANDO(S).", numComandosDesfazer);

            while (numComandosDesfazer > 0 && _desfazerPilha.Count > 0)
            {
                RoboCommand comand = _desfazerPilha.Pop();
                comand.Desfazer();
                numComandosDesfazer--;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Robo robo = new Robo();
            //RoboControle controle = new RoboControle();

            //MoverCommand mover = new MoverCommand(robo);
            //mover.ParaFrente = 1000;
            //controle.Comandos.Enqueue(mover);

            //RotacionarCommand rotacionar = new RotacionarCommand(robo);
            //rotacionar.rotacionarParaEsquerda = 45;
            //controle.Comandos.Enqueue(rotacionar);

            //EscavarCommand escavar = new EscavarCommand(robo);
            //escavar.ColherMaterial = true;
            //controle.Comandos.Enqueue(escavar);

            //controle.ExecutarComandos();
            //controle.DesfazerComandos(3);






            Cliente cliente = new Cliente("Rick");
            ClienteControle controle = new ClienteControle();

            ApertarCommand apertar = new ApertarCommand(cliente);
            apertar.horas = 2;
            controle.Comandos.Enqueue(apertar);

            PedirCommand pedir = new PedirCommand(cliente);
            pedir.desconto = 45;
            controle.Comandos.Enqueue(pedir);

            ReclamarCommand reclamar = new ReclamarCommand(cliente);
            reclamar.reclamacao = true;
            controle.Comandos.Enqueue(reclamar);

            controle.ExecutarComandos();
            controle.DesfazerComandos(3);


            Console.ReadKey();
        }
    }
}
