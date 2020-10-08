using Pattern_Factory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Factory.Service
{

    public class SpanishAloMundo : IAloMundo
    {
        public void falaAlo()
        {
            Console.WriteLine("Hola Mundo");
        }
    }
}
