using System;
using System.Collections.Generic;

namespace Pattern_BridgeRealWorld
{
    internal class CustomersData : DataObject
    {
        private List<string> _customers = new List<string>();
        private int _current = 0;

        public CustomersData()
        {
            _customers.Add("Jim Jones");
            _customers.Add("Samual Jackson");
            _customers.Add("Allen Good");
            _customers.Add("Ann Stills");
            _customers.Add("Lisa Giolani");
        }

        public override void AddRecord(string customer)
        {
            _customers.Add(customer);
        }

        public override void NextRecord()
        {
            if (_current <= _customers.Count - 1)
            {
                _current++;
            }
        }

        public override void PriorRecord()
        {
            if (_current > 0)
            {
                _current--;
            }
        }

        public override void ShowAllRecords()
        {
            foreach (string customer in _customers)
            {
                Console.WriteLine(" " + customer);
            }
        }

        public override void ShowRecord()
        {
            Console.WriteLine(_customers[_current]);
        }
    }

    class Customers : CustomersBase
    {
        public Customers(string group) : base(group)
        {
        }

        public override void ShowAll()
        {
            // Add separator lines
            Console.WriteLine();
            Console.WriteLine("------------------------");
            base.ShowAll();
            Console.WriteLine("------------------------");
        }
    }

    abstract class DataObject
    {
        public abstract void NextRecord();
        public abstract void PriorRecord();
        public abstract void AddRecord(string name);
        //public abstract void DeleteRecord(string name);
        public abstract void ShowRecord();
        public abstract void ShowAllRecords();
    }

    class CustomersBase
    {
        private DataObject _dataObject;
        protected string group;

        public CustomersBase(string group)
        {
            this.group = group;
        }

        public DataObject Data
        {
            set { _dataObject = value; }
            get { return _dataObject; }
        }

        public virtual void Next()
        {
            _dataObject.NextRecord();
        }

        public virtual void Prior()
        {
            _dataObject.PriorRecord();
        }

        public virtual void Add(string customer)
        {
            _dataObject.AddRecord(customer);
        }

        public virtual void Show()
        {
            _dataObject.ShowRecord();
        }

        public virtual void ShowAll()
        {
            Console.WriteLine("Customer Group: " + group);
            _dataObject.ShowAllRecords();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customers customers = new Customers("Chicago");

            customers.Data = new CustomersData();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();

            customers.Add("Henry Velasquez");
            customers.ShowAll();

            Console.ReadKey();
        }
    }

}