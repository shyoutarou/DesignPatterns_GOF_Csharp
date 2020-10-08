using Pattern_AbstractFactory2.Interface;
using System;

namespace Pattern_AbstractFactory2.Service.Connection
{
    class MySqlConnection : IConnection
    {
        public String conectar()
        {
            return "Conectado a MySQL";
        }

        public void FunctionB(IAloMundo linguas)
        {
            Console.WriteLine("The result FunctionB:");
            linguas.falaAlo();
        }
    }
}
