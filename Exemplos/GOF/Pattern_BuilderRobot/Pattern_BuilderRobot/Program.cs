using System;
using System.Collections;

namespace Pattern_BuilderRobot
{
    public interface RobotBuilder
    {
        void addStart();
        void addGetParts();
        void addAssemble();
        void addTest();
        void addStop();
        RobotBuildable getRobot();
    }

    public interface RobotBuildable
    {
        void go();
    }

   

    public class AutomotiveRobotBuilder : RobotBuilder
    {
        ArrayList actions;
        AutomotiveRobotBuildable robot;

        public AutomotiveRobotBuilder()
        {
            robot = new AutomotiveRobotBuildable();
            actions = new ArrayList();
        }
        public void addStart()
        {
            actions.Add(1);
        }
        public void addGetParts()
        {
            actions.Add(2);
        }
        public void addAssemble()
        {
            actions.Add(3);
        }
        public void addTest()
        {
            actions.Add(4);
        }
        public void addStop()
        {
            actions.Add(5);
        }
        public RobotBuildable getRobot()
        {
            robot.loadActions(actions);
            return robot;
        }
    }

    internal class AutomotiveRobotBuildable : RobotBuildable
    {
        ArrayList actions;

        public void go()
        {
            foreach (var item in actions)
            {
                switch (item)
                {
                    case 1:
                        start();
                        break;
                    case 2:
                        getParts();
                        break;
                    case 3:
                        assemble();
                        break;
                    case 4:
                        test();
                        break;
                    case 5:
                        stop();
                        break;
                }
            }
        }

        public void start()
        {
            Console.WriteLine("Starting....");
        }
        public void getParts()
        {
            Console.WriteLine("Getting a carburetor....");
        }
        public void assemble()
        {
            Console.WriteLine("Installing the carburetor....");
        }
        public void test()
        {
            Console.WriteLine("Revving the engine....");
        }
        public void stop()
        {
            Console.WriteLine("Stopping....");
        }
        public void loadActions(ArrayList a)
        {
            actions = a;
        }
    }

 
    public class CookieRobotBuilder : RobotBuilder
    {
        ArrayList actions;
        CookieRobotBuildable robot;

        public CookieRobotBuilder()
        {
            robot = new CookieRobotBuildable();
            actions = new ArrayList();
        }
        public void addStart()
        {
            actions.Add(1);
        }
        public void addGetParts()
        {
            actions.Add(2);
        }
        public void addAssemble()
        {
            actions.Add(3);
        }
        public void addTest()
        {
            actions.Add(4);
        }
        public void addStop()
        {
            actions.Add(5);
        }
        public RobotBuildable getRobot()
        {
            robot.loadActions(actions);
            return robot;
        }
    }

    internal class CookieRobotBuildable : RobotBuildable
    {
        ArrayList actions;

        public void go()
        {
            foreach (var item in actions)
            {
                switch (item)
                {
                    case 1:
                        start();
                        break;
                    case 2:
                        getParts();
                        break;
                    case 3:
                        assemble();
                        break;
                    case 4:
                        test();
                        break;
                    case 5:
                        stop();
                        break;
                }
            }
        }

        public void start()
        {
            Console.WriteLine("Starting....");
        }
        public void getParts()
        {
            Console.WriteLine("Getting flour and sugar....");
        }
        public void assemble()
        {
            Console.WriteLine("Baking a cookie....");
        }
        public void test()
        {
            Console.WriteLine("Crunching a cookie....");
        }
        public void stop()
        {
            Console.WriteLine("Stopping....");
        }
        public void loadActions(ArrayList a)
        {
            actions = a;
        }
    }

 
    class Program
    {
        static void Main(string[] args)
        {
            RobotBuilder builder;
            RobotBuildable robot;

            Console.WriteLine("Do you want a cookie robot[c] or an automotive one[a] ? ");
            var response = Console.ReadKey();

            if (response.Equals('c'))
            {
                builder = new CookieRobotBuilder();
            }
            else
            {
                builder = new AutomotiveRobotBuilder();
            }

            builder.addStart();
            builder.addTest();
            builder.addAssemble();
            builder.addStop();
            robot = builder.getRobot();
            robot.go();


            Console.ReadKey();
        }
    }
}
