using Pattern_Factory_GoFWay.Interface;
using System;

namespace Pattern_Factory_GoFWay.Service
{
    public class SecureOracleConnection : IConnection
    {
        public String description()
        {
            return "Oracle secure";
        }
    }
}
