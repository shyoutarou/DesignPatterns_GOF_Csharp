using System;
using System.Collections.Generic;

namespace Pattern_Observer
{
    interface Sujeito
    {
        void RegistrarObservador(Observador o);
        void RemoverObservador(Observador o);
        void NotificarObservadores();
    }

    interface Observador
    {
        void Atualizar(Sujeito sujeito);
    }


    class EditoraConcreta : Sujeito
    {
        private List<Observador> observadores = new List<Observador>();
        private bool _novaEdicao = false;

        public void RegistrarObservador(Observador o)
        {
            observadores.Add(o);
        }

        public void RemoverObservador(Observador o)
        {
            observadores.Remove(o);
        }

        public void NotificarObservadores()
        {
            foreach (Observador o in observadores)
            {
                o.Atualizar(this);
            }
        }

        public void alterarEdicao()
        {
            if (_novaEdicao)
                _novaEdicao = false;
            else
                _novaEdicao = true;
            NotificarObservadores();
        }

        public Boolean getEdicao()
        {
            return _novaEdicao;
        }
    }

    class AssinanteConcreto : Observador
    {
        private EditoraConcreta objetoObservado;

        public AssinanteConcreto(EditoraConcreta o)
        {
            objetoObservado = o;
            objetoObservado.RegistrarObservador(this);
        }

        public void Atualizar(Sujeito sujeito)
        {
            if (sujeito == objetoObservado)
            {
                Console.WriteLine("[Aviso] - A editora alterou o seu estado para : " + objetoObservado.getEdicao());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EditoraConcreta editora = new EditoraConcreta();
            // Editora ja inicia com valor padrão igual a false
            AssinanteConcreto assinante1 = new AssinanteConcreto(editora);
            AssinanteConcreto assinante2 = new AssinanteConcreto(editora);
            AssinanteConcreto assinante3 = new AssinanteConcreto(editora);
            AssinanteConcreto assinante4 = new AssinanteConcreto(editora);
            AssinanteConcreto assinante5 = new AssinanteConcreto(editora);

            // Já passando a editora como parametro
            editora.alterarEdicao();
            // Nesse momento é chamado o método atualizar
            // das instâncias assinante1 e assinante2, resultadao:
            // [Aviso] A Editora mudou seu estado para: true (5 x) 
            editora.alterarEdicao();
            //[Aviso] A Editora mudou seu estado para: false (5 x)
            // Obs: temos 5 saídas porque temos 5 assinantes
            Console.ReadKey();
        }
    }
}
