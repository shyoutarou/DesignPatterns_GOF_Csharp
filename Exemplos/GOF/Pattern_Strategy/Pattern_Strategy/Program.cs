using System;

namespace Pattern_Strategy
{
    public interface IPromocao
    {
        decimal desconto();
    }

    public interface IDescricao
    {
        void escrever();
    }

    public abstract class Produto
    {
        protected IPromocao _promocao;
        protected IDescricao _descricao;
        public decimal desconto()
        {
            return _promocao.desconto();
        }

        public void descricao()
        {
            _descricao.escrever();
        }

        public void setPromocao(IPromocao promotion)
        {
            _promocao = promotion;
        }

        public void setDescricao(IDescricao description)
        {
            _descricao = description;
        }
    }


    class ProdEletronicos : IDescricao
    {
        public void escrever()
        {
            Console.WriteLine("Sou um eletrônico");
        }
    }

    class ProdAlimentos : IDescricao
    {
        public void escrever()
        {
            Console.WriteLine("Sou um alimento");
        }
    }

    class ProdBrinquedos : IDescricao
    {
        public void escrever()
        {
            Console.WriteLine("Sou um brinquedo");
        }
    }

    class PromocaoNatal : IPromocao
    {
        public decimal desconto()
        {
            return 10;
        }
    }

    class PromocaoNamorados : IPromocao
    {
        public decimal desconto()
        {
            return 15;
        }
    }


    public class DVD : Produto
    {
        public DVD()
        {
            setPromocao(new PromocaoNatal());
            setDescricao(new ProdEletronicos());

            this._promocao = new PromocaoNatal();
            this._descricao = new ProdEletronicos();
        }
    }

    public class Celular : Produto
    {
        public Celular()
        {
            setPromocao(new PromocaoNamorados());
            setDescricao(new ProdEletronicos());
        }
    }

    public class Boneca : Produto
    {
        public Boneca()
        {
            this._promocao = new PromocaoNamorados();
            this._descricao = new ProdBrinquedos();
        }
    }

    public class Gelatina : Produto
    {
        public Gelatina()
        {
            this._promocao = new PromocaoNamorados();
            this._descricao = new ProdAlimentos();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dvd = new DVD();
            var celular = new Celular();
            var boneca = new Boneca();
            var gelatina = new Gelatina();

            dvd.descricao(); // Sou um eletrônico
            celular.descricao(); // Sou um eletrônico
            boneca.descricao(); // Sou um brinquedo
            gelatina.descricao(); // Sou um alimento


            gelatina.setDescricao(new ProdEletronicos());
            gelatina.descricao(); // Sou um eletrônico
            gelatina.setDescricao(new ProdBrinquedos());
            gelatina.descricao(); // Sou um brinquedo

            Console.WriteLine("DVD desconto:  " + dvd.desconto()); // 10
            Console.WriteLine("Celular desconto:  " + celular.desconto()); // 15
            Console.ReadKey();
        }
    }
}
