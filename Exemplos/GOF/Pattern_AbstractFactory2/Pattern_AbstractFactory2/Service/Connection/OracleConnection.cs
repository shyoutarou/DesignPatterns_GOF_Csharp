﻿using Pattern_AbstractFactory2.Interface;
using System;

namespace Pattern_AbstractFactory2.Service.Connection
{
    public class OracleConnection : IConnection
    {
        public String conectar()
        {
            return "Conectado a Oracle";
        }

        public void FunctionB(IAloMundo linguas)
        {
            Console.WriteLine("The result FunctionB:");
            linguas.falaAlo();
        }
    }
}
