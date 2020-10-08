using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cria uma sala de chat (chatsala)
            ChatSala chatsala = new ChatSala();

            // cria participantes e faz o registro
            Participante Macoratti = new Membro("Macoratti");
            Participante Miriam = new Membro("Miriam");
            Participante Jefferson = new Membro("Jefferson");
            Participante Janice = new Membro("Janice");
            Participante Jessica = new NaoMembro("Jessica");

            // registra os participantes
            chatsala.Registro(Macoratti);
            chatsala.Registro(Miriam);
            chatsala.Registro(Jefferson);
            chatsala.Registro(Janice);
            chatsala.Registro(Jessica);

            // Inicia o chat 
            Jessica.Enviar("Janice", "Olá, Janice!");
            Miriam.Enviar("Jefferson", "Como vai você");
            Jefferson.Enviar("Macoratti", "Tudo bem");
            Miriam.Enviar("Janice", "Como você esta ?");
            Janice.Enviar("Jessica", "Tudo tranquilo...");

            // aguarda...
            Console.ReadKey();
        }
    }


    public class ChatSala : AbstractChatSala
    {
        private Dictionary<string, Participante> _participantes = new Dictionary<string, Participante>();

        public override void Registro(Participante _participante)
        {
            if (!_participantes.ContainsValue(_participante))
                _participantes[_participante.Nome] = _participante;

            _participante.ChatSala = this;
        }

        public override void Enviar(string de, string para, string mensagem)
        {
            Participante _participante = _participantes[para];
            if (_participante != null)
                _participante.Receber(de, mensagem);
        }
    }


    public abstract class AbstractChatSala
    {
        public abstract void Registro(Participante participante);
        public abstract void Enviar(string de, string para, string message);
    }

    public class NaoMembro : Participante
    {
        // Construtor
        public NaoMembro(string nome) : base(nome)
        {
        }
        // sobrescreve o método Receber
        public override void Receber(string de, string mensagem)
        {
            Console.Write("Para NaoMembro : ");
            base.Receber(de, mensagem);
        }
    }

    public class Membro : Participante
    {
        // Construtor
        public Membro(string nome) : base(nome)
        {
        }
        // sobrescreve o método Receber
        public override void Receber(string de, string mensagem)
        {
            Console.Write("para Membro : ");
            base.Receber(de, mensagem);
        }
    }

    public abstract class Participante
    {
        private ChatSala _chatsala;
        private string _nome;

        public int MyProperty { get; set; }

        public string Nome
        {
            get { return _nome; }
        }

        public ChatSala ChatSala
        {
            get { return _chatsala; }
            set { _chatsala = value; }
        }


        public Participante(string nome)
        {
            _nome = nome;
        }

        // Envia mensagem para um dado participante
        public void Enviar(string para, string mensagem)
        {
            _chatsala.Enviar(_nome, para, mensagem);
        }

        // Recebe mensagem de um participante
        public virtual void Receber(string de, string mensagem)
        {
            Console.WriteLine("{0} para {1}: '{2}'", de, Nome, mensagem);
        }
    }
}
