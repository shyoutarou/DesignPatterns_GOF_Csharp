using Pattern_AbstractFactory2.Interface;
using System;

namespace Pattern_AbstractFactory2.Service.Connection
{
    public class GermanAloMundo : IAloMundo
    {
        public void falaAlo()
        {
            Console.WriteLine("Hallo Welt");
        }
    }
}
