using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Visitor
{
    abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }

    interface IVisitor
    {
        void Visit(Element element);
    }

    class Employee : Element
    {
        private string _name;
        private double _income;
        private int _vacationDays;

        public Employee(string name, double income, int vacationDays)
        {
            this._name = name;
            this._income = income;
            this._vacationDays = vacationDays;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Income
        {
            get { return _income; }
            set { _income = value; }
        }

        public int VacationDays
        {
            get { return _vacationDays; }
            set { _vacationDays = value; }
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Employees
    {
        private List<Employee> _employees = new List<Employee>();
        public void Attach(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Detach(Employee employee)
        {
            _employees.Remove(employee);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Employee e in _employees)
            {
                e.Accept(visitor);
            }

            Console.WriteLine();
        }
    }

    class Clerk : Employee
    {
        public Clerk() : base("Hank", 25000.0, 14)
        {
        }
    }

    class Director : Employee
    {
        public Director() : base("Elly", 35000.0, 16)
        {
        }
    }

    class President : Employee
    {
        public President() : base("Dick", 45000.0, 21)
        {
        }
    }

    class IncomeVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;
            employee.Income *= 1.10;

            Console.WriteLine("{0} {1}'s new income: {2:C}",
              employee.GetType().Name, employee.Name,
              employee.Income);
        }
    }

    class VacationVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;
            employee.VacationDays += 3;

            Console.WriteLine("{0} {1}'s new vacation days: {2}",
              employee.GetType().Name, employee.Name,
              employee.VacationDays);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employees e = new Employees();
            e.Attach(new Clerk());
            e.Attach(new Director());
            e.Attach(new President());

            // Employees are 'visited'
            e.Accept(new IncomeVisitor());
            e.Accept(new VacationVisitor());

            Console.ReadKey();
        }
    }


}
