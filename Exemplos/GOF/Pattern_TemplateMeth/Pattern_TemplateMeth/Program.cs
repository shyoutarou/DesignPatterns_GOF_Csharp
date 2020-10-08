using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_TemplateMeth
{
    public abstract class RobotTemplate
    {
        public void go()
        {
            start();
            getParts();
            assemble();
            test();
            stop();
        }

        public virtual void start() { Console.WriteLine("Starting...."); }
        public virtual void getParts() { Console.WriteLine("Getting parts...."); }
        public virtual void assemble() { Console.WriteLine("Assembling...."); }
        public virtual void test() { Console.WriteLine("Testing...."); }
        public virtual void stop() { Console.WriteLine("Stopping...."); }
    }


    public class AutomotiveRobot : RobotTemplate
    {
        private String name;
        public AutomotiveRobot(String n)
        {
            name = n;
        }
        public override void getParts()
        {
            Console.WriteLine("Getting a carburetor....");
        }
        public override void assemble()
        {
            Console.WriteLine("Installing the carburetor....");
        }
        public override void test()
        {
            Console.WriteLine("Revving the engine....");
        }
        public String getName() { return name; }
    }

    public class CookieRobot : RobotTemplate
    {
        private String name;
        public CookieRobot(String n)
        {
            name = n;
        }
        public override void getParts()
        {
            Console.WriteLine("Getting flour and sugar....");
        }
        public override void assemble()
        {
            Console.WriteLine("Baking a cookie....");
        }
        public override void test()
        {
            Console.WriteLine("Crunching a cookie....");
        }
        public String getName() { return name; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AutomotiveRobot automotiveRobot = new AutomotiveRobot("Automotive Robot");
            CookieRobot cookieRobot = new CookieRobot("Cookie Robot");
            Console.WriteLine(automotiveRobot.getName() + ":");
            automotiveRobot.go();

            Console.WriteLine();
            Console.WriteLine(cookieRobot.getName() + ":");
            cookieRobot.go();

            Console.ReadLine();
        }
    }
}
