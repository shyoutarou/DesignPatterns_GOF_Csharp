using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patterns_Sigletonthread
{
    public class Database_NonSingleton
    {
        private int record;
        private String name;
        public Database_NonSingleton(String n)
        {
            name = n;
            record = 0;
        }
        public void editRecord(String operation)
        {
            Console.WriteLine("Performing a " + operation +
                                " operation on record " + record +
                                " in database " + name);
        }
        public String getName()
        {
            return name;
        }
    }



    public class Database
    {
        private static Database singleObject;
        private int record;
        private String name;
        private Database(String n)
        {
            name = n;
            record = 0;
        }

        public static Database getInstance(String n)
        {
            if (singleObject == null)
            {
                singleObject = new Database(n);
            }
            return singleObject;
        }

        public void editRecord(String operation)
        {
            Console.WriteLine("Performing a " + operation +
                                " operation on record " + record +
                                " in database " + name);
        }
        public String getName()
        {
            return name;
        }
    }

    public class DatabaseThreaded
    {
        private static DatabaseThreaded singleObject = new DatabaseThreaded("products");
        private int record;
        private String name;
        private DatabaseThreaded(String n)
        {
            name = n;
            record = 0;
        }
        public static DatabaseThreaded getInstance(String n)
        {
            return singleObject;
        }
        public void editRecord(String operation)
        {
            Console.WriteLine("Performing a " + operation +
                                " operation on record " + record +
                                " in database " + name);
        }
        public String getName()
        {
            return name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Database_NonSingleton dataOne = new Database_NonSingleton("Products");
            Database_NonSingleton dataTwo = new Database_NonSingleton("Products Also");
            Database_NonSingleton dataThree = new Database_NonSingleton("Products Again");


            //Database database;
            //database = Database.getInstance("products");
            ////This is the products database.
            //Console.WriteLine("This is the " + database.getName() + " database.");

            //database = Database.getInstance("employees");
            ////This is the products database.
            //Console.WriteLine("This is the " + database.getName() + " database.");


            TestSingletonThreaded();


            Console.ReadKey();
        }


        public static void TestSingletonThreaded()
        {
            DatabaseThreaded database;
            database = DatabaseThreaded.getInstance("products");
            var thread = new Thread(run);

            thread.Start();
            Console.WriteLine("This is the " + database.getName() + " database.");
        }

        public static void run()
        {
            DatabaseThreaded database;
            database = DatabaseThreaded.getInstance("employees");
            Console.WriteLine("This is the " + database.getName() + " database.");
        }


    }
}
