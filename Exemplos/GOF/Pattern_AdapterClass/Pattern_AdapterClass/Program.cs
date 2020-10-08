using System;

namespace Pattern_AdapterClass
{
    public class NewClass
    {
        String name;
        public void setName(String n) { name = n; }
        public String getName() { return name; }
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

    public class NewToLegacyAdapter : LegacyClass
    {
        public NewToLegacyAdapter(NewClass NewObject)
        {
            setFirstName(NewObject.getName().Split(' ')[0]);
            setLastName(NewObject.getName().Split(' ')[1]);
        }

        public new String getFirstName()
        {
            return getFirstName();
        }

        public new String getLastName()
        {
            return getLastName();
        }
    }

    //public class OtherNewClass
    //{
    //    String firstName;
    //    String lastName;
    //    public void setFirstName(String f) { firstName = f; }
    //    public void setLastName(String l) { lastName = l; }
    //    public String getFirstName() { return firstName; }
    //    public String getLastName() { return lastName; }
    //}

    //public class OtherNewToLegacyAdapter : OtherNewClass
    //{
    //    public OtherNewToLegacyAdapter(NewClass NewObject)
    //    {
    //        setFirstName(NewObject.getName().Split(' ')[0]);
    //        setLastName(NewObject.getName().Split(' ')[1]);
    //    }

    //    public new String getFirstName()
    //    {
    //        return getFirstName();
    //    }

    //    public new String getLastName()
    //    {
    //        return getLastName();
    //    }
    //}


    class Program
    {
        static void Main(string[] args)
        {
            NewClass NewObject = new NewClass();
            NewObject.setName("Cary Grant");
            LegacyClass adapter = new NewToLegacyAdapter(NewObject);

            Console.WriteLine("Customer’s first name: " + adapter.getFirstName());
            Console.WriteLine("Customer’s last name: " + adapter.getLastName());

            Console.ReadKey();
        }
    }
}
