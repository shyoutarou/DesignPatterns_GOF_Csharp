using System;

namespace Pattern_ChainRespo
{
    public interface HelpInterface
    {
        void GetHelp(int helpConstant);
    }

    public class FrontEnd : HelpInterface
    {
        const int FRONT_END_HELP = 1;
        HelpInterface successor;
        public FrontEnd(HelpInterface s)
        {
            successor = s;
        }
        public void GetHelp(int helpConstant)
        {
            if (helpConstant != FRONT_END_HELP)
            {
                successor.GetHelp(helpConstant);
            }
            else
            {
                Console.WriteLine("This is the front end.Don’t you like it ?");
            }
        }
    }

    public class IntermediateLayer : HelpInterface
    {
        const int INTERMEDIATE_LAYER_HELP = 2;
        HelpInterface successor;
        public IntermediateLayer(HelpInterface s)
        {
            successor = s;
        }
        public void GetHelp(int helpConstant)
        {
            if (helpConstant != INTERMEDIATE_LAYER_HELP)
            {
                successor.GetHelp(helpConstant);
            }
            else
            {
                Console.WriteLine("This is the intermediate layer.Nice, eh ?");
            }
        }
    }

    public class Application : HelpInterface
    {
        public Application()
        {
        }
        public void GetHelp(int helpConstant)
        {
            Console.WriteLine("This is the MegaGigaCo application.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int FRONT_END_HELP = 1;
            const int INTERMEDIATE_LAYER_HELP = 2;
            const int GENERAL_HELP = 3;
            Application app = new Application();
            IntermediateLayer intermediateLayer = new IntermediateLayer(app);
            FrontEnd frontEnd = new FrontEnd(intermediateLayer);
            frontEnd.GetHelp(GENERAL_HELP); // This is the MegaGigaCo application.

            Console.ReadKey();
        }
    }
}
