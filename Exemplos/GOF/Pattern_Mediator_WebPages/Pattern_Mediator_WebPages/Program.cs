using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Mediator_WebPages
{
    public class Welcome
    {
        Mediator mediator;
        String response = "n";
        public Welcome(Mediator m)
        {
            mediator = m;
        }
        public void go()
        {
            Console.WriteLine("Do you want to shop?[y / n] ? ");
            try
            {
                response = Console.ReadLine();
                if (response.Equals("y")) mediator.handle("welcome.shop");
                else mediator.handle("welcome.exit");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }

        }
    }


    public class Shop
    {
        Mediator mediator;
        String response = "n";
        public Shop(Mediator m)
        {
            mediator = m;
        }
        public void go()
        {
            Console.WriteLine("Are you ready to purchase?[y / n] ? ");

            try
            {
                response = Console.ReadLine();
                if (response.Equals("y")) mediator.handle("shop.purchase");
                else mediator.handle("shop.exit");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }
        }
    }


    public class Mediator
    {
        Welcome welcome;
        Shop shop;
        Purchase purchase;
        Exit exit;
        public Mediator()
        {
            welcome = new Welcome(this);
            shop = new Shop(this);
            purchase = new Purchase(this);
            exit = new Exit(this);
        }

        public void handle(String state)
        {
            if (state.Equals("welcome.shop"))
            {
                shop.go();
            }
            else if (state.Equals("shop.purchase"))
            {
                purchase.go();
            }
            else if (state.Equals("purchase.exit"))
            {
                exit.go();
            }
            else if (state.Equals("welcome.exit"))
            {
                exit.go();
            }
            else if (state.Equals("shop.exit"))
            {
                exit.go();
            }
            else if (state.Equals("purchase.exit"))
            {
                exit.go();
            }
        }
        public Welcome getWelcome()
        {
            return welcome;
        }
    }

    public class Exit
    {
        Mediator mediator;
        public Exit(Mediator m)
        {
            mediator = m;
        }
        public void go()
        {
            Console.WriteLine("Please come again sometime.");
        }
    }

    public class Purchase
    {
        Mediator mediator;
        String response = "n";
        public Purchase(Mediator m)
        {
            mediator = m;
        }
        public void go()
        {
            Console.WriteLine("Buy the item now?[y / n] ? ");
            try
            {
                response = Console.ReadLine();
                if (response.Equals("y")) mediator.handle("Thanks for your purchase.");
                else mediator.handle("purchase.exit");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            mediator.getWelcome().go();
        }
    }
}
