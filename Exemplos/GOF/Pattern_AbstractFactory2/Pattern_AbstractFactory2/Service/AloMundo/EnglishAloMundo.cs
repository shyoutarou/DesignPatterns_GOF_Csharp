using Pattern_AbstractFactory2.Interface;
using System;

namespace Pattern_AbstractFactory2.Service.Connection
{
    public class EnglishAloMundo : IAloMundo
    {
        public void falaAlo()
        {
            Console.WriteLine("Hello World");
        }
    }
}
