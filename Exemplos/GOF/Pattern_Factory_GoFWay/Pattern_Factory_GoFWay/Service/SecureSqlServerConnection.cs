using Pattern_Factory_GoFWay.Interface;
using System;

namespace Pattern_Factory_GoFWay.Service
{
    public class SecureSqlServerConnection : IConnection
    {
        public String description()
        {
            return "SQL Server secure";
        }
    }
}
