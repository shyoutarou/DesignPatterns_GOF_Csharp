using Pattern_Factory_GoFWay.Interface;
using System;

namespace Pattern_Factory_GoFWay.Service
{
    public class SecureMySqlConnection : IConnection
    {
        public String description()
        {
            return "MySQL secure";
        }
    }
}
