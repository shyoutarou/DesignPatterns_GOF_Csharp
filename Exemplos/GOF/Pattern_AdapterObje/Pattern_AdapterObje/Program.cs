using System;

namespace Pattern_AdapterObje
{
    public interface NewInterface
    {
        void setName(String n);
        String getName();
    }

    public class NewClass : NewInterface
    {
        String name;
        public void setName(String n) { name = n; }
        public String getName() { return name; }
    }

    public class OtherNewClass : NewInterface
    {
        String name;
        public void setName(String n) { name = n; }
        public String getName() { return name; }
        public Int32 SupernessLevel { get { return this.name.Length * 100; } }
    }

    public class LegacyClass
    {
        String firstName;
        String lastName;
        public void setFirstName(String f) { firstName = f; }
        public void setLastName(String l) { lastName = l; }
        public String getFirstName() { return firstName; }
        public String getLastName() { return lastName; }
    }


    public class NewToLegacyAdapter
    {
        String firstName;
        String lastName;
        public NewToLegacyAdapter(NewInterface NewObject)
        {
            firstName = NewObject.getName().Split(' ')[0];
            lastName = NewObject.getName().Split(' ')[1];
        }
        public void setFirstName(String f) { firstName = f; }
        public void setLastName(String l) { lastName = l; }
        public String getFirstName() { return firstName; }
        public String getLastName() { return lastName; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NewClass NewObject = new NewClass();
            NewObject.setName("Cary Grant");
            NewToLegacyAdapter adapter = new NewToLegacyAdapter(NewObject);

            Console.WriteLine("Customer’s first name: " + adapter.getFirstName());
            Console.WriteLine("Customer’s last name: " + adapter.getLastName());

            OtherNewClass OtherNewClass = new OtherNewClass();
            NewObject.setName("Cary Grant");
            adapter = new NewToLegacyAdapter(OtherNewClass);

            Console.WriteLine("Other Customer’s first name: " + adapter.getFirstName());
            Console.WriteLine("Other Customer’s last name: " + adapter.getLastName());


            Console.ReadKey();
        }
    }
}
