using System;
using System.Collections;
using System.Collections.Generic;

namespace Pattern_Composite
{
    public abstract class Corporate
    {
        public String getName() { return ""; }
        public void add(Corporate c) { }
        public List<Corporate> iterator() { return null; }
        public virtual void print() { }
    }

    public class Fornecedor : Corporate
    {
        private String name;
        private String setor;
        public Fornecedor(String n, String d)
        {
            name = n;
            setor = d;
        }
        public String getName() { return name; }
        public override void print()
        {
            Console.WriteLine("Name: " + name + " Setor: " + setor);
        }

        public FornecedorIterator iterator()
        {
            return new FornecedorIterator(this);
        }
    }

    public class FornecedorIterator : IEnumerator
    {
        private Fornecedor Fornecedor;

        public FornecedorIterator(Fornecedor f)
        {
            Fornecedor = f;
        }

        public object Current { get { return Fornecedor; } }

        public Fornecedor Next() { return Fornecedor; }

        public bool MoveNext() { return false; }

        public void Reset() { }
    }

    public class Setor : Corporate
    {
        private Corporate[] Fornecedores = new Corporate[100];
        private int number = 0;
        private String name;
        public Setor(String n)
        {
            name = n;
        }
        public String getName() { return name; }
        public void add(Corporate n) { Fornecedores[number++] = n; }
        public SetorIterator iterator()
        {
            return new SetorIterator(Fornecedores);
        }

        public override void print()
        {
            SetorIterator setoriterator = iterator();
            while (setoriterator.MoveNext())
            {
                Corporate c = (Corporate)setoriterator.Next();
                c.print();
            }
        }
    }

    public class SetorIterator : IEnumerator
    {
        private Corporate[] Fornecedores;
        private int index = 0;

        public SetorIterator(Corporate[] v)
        {
            Fornecedores = v;
        }

        public object Current { get { return Fornecedores[index]; } }

        public Corporate Next()
        {
            return Fornecedores[index++];
        }

        public bool MoveNext()
        {
            return (index < Fornecedores.Length && Fornecedores[index] != null);
        }

        public void Reset()
        {
            index = -1;
        }
    }

    public class Corporation : Corporate
    {
        private List<Corporate> corporate = new List<Corporate>();
        public Corporation()
        {
        }
        public void add(Corporate c)
        {
            corporate.Add(c);
        }
        public void print()
        {
            using (IEnumerator<Corporate> enumerator = corporate.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Corporate c = (Corporate)enumerator.Current;
                    c.print();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TestDivision();

            Console.ReadKey();
        }

        public static void TestDivision()
        {

            var corporation = new Corporation();

            Setor setor = new Setor("Alimentos");
            setor.add(new Fornecedor("Sadia", "Alimentos"));
            setor.add(new Fornecedor("Seara", "Alimentos"));
            setor.add(new Fornecedor("Brasil Foods", "Alimentos"));
            setor.add(new Fornecedor("Perdigao", "Alimentos"));

            Setor limpeza = new Setor("Limpeza");
            limpeza.add(new Fornecedor("OMO", "Limpeza"));
            limpeza.add(new Fornecedor("Bombril", "Limpeza"));
            limpeza.add(new Fornecedor("Ipe", "Limpeza"));

            Setor bebidas = new Setor("Bebidas");
            bebidas.add(new Fornecedor("Coca", "Bebidas"));
            bebidas.add(new Fornecedor("Fanta", "Bebidas"));

            limpeza.add(new Fornecedor("Veja", "Limpeza"));

            corporation.add(setor);
            corporation.add(limpeza);
            corporation.add(bebidas);
            corporation.print();
        }
    }
}
