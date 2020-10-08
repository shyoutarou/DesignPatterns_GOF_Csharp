using Pattern_Factory_GoFWay.Interface;
using Pattern_Factory_GoFWay.Service;
using System;

namespace Pattern_Factory_GoFWay.Factories
{
    public class SecureFactory
    {
        public IConnection createConnection(String type)
        {
            switch (type)
            {
                case "Oracle": return new SecureOracleConnection();
                case "SQL Server": return new SecureSqlServerConnection();
                default: return new SecureMySqlConnection();
            }
        }
    }
}
