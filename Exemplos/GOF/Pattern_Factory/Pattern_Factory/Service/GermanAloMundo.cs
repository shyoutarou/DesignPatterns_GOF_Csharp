using Pattern_Factory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Factory.Service
{
    public class GermanAloMundo : IAloMundo
    {
        public void falaAlo()
        {
            Console.WriteLine("Hallo Welt");
        }
    }
}
