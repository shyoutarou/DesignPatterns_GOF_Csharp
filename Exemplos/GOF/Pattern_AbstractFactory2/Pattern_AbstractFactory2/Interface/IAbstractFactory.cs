using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_AbstractFactory2.Interface
{
    public interface IAbstractFactory
    {
        IAloMundo CriaAloMundo(string idioma);
        IConnection CriaConnection(string type);
    }
}
