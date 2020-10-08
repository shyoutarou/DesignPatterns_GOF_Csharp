using System;
using System.Collections;
using System.Collections.Generic;

namespace Pattern_Iterador
{
    public class Fornecedor
    {
        private String name;
        private String setor;
        public Fornecedor(String n, String d)
        {
            name = n;
            setor = d;
        }
        public String getName()
        {
            return name;
        }
        public void print()
        {
            Console.WriteLine("Name: " + name + " Setor: " + setor);
        }
    }

    public class Setor
    {
        private Fornecedor[] Fornecedores = new Fornecedor[100];
        private int number = 0;
        private String name;
        public Setor(String n)
        {
            name = n;
        }
        public String getName()
        {
            return name;
        }
        public void add(String n)
        {
            Fornecedor vp = new Fornecedor(n, name);
            Fornecedores[number++] = vp;
        }
        public SetorIterator iterator()
        {
            return new SetorIterator(Fornecedores);
        }
    }

    public class SetorIterator : IEnumerator
    {
        private Fornecedor[] Fornecedores;
        private int index = 0;

        public SetorIterator(Fornecedor[] v)
        {
            Fornecedores = v;
        }

        public object Current { get { return Fornecedores[index]; } }

        public Fornecedor Next()
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

    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 5, 7, 9 };
            using (IEnumerator<int> enumerator = numbers.GetEnumerator())
            {
                // 1 - 2 - 3 - 5 - 7 - 9 -
                while (enumerator.MoveNext()) Console.Write(enumerator.Current + " - ");
            }

            TestDivision();

            Console.ReadKey();
        }

        public static void TestDivision()
        {
            Setor setor = new Setor("Alimentos");
            setor.add("Sadia");
            setor.add("Seara");
            setor.add("Brasil Foods");
            setor.add("Perdigao");

            SetorIterator iterator = setor.iterator();
            while (iterator.MoveNext())
            {
                Fornecedor vp = iterator.Next();
                vp.print();
            }
        }
    }
}
