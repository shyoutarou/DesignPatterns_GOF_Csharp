using Pattern_AbstractFactory2.Interface;
using Pattern_AbstractFactory2.Service.Connection;

namespace Pattern_AbstractFactory2.Factories
{


    public class ConcreteFactory : IAbstractFactory
    {
        public IConnection CriaConnection(string type)
        {
            switch (type)
            {
                case "my": return new MySqlConnection();
                case "or": return new OracleConnection();
                case "ss": return new SqlServerConnection();
                default: return new SqlServerConnection();
            }
        }

        public IAloMundo CriaAloMundo(string idioma)
        {
            switch (idioma)
            {
                case "en": return new EnglishAloMundo();
                case "sp": return new SpanishAloMundo();
                case "de": return new GermanAloMundo();
                default: return new EnglishAloMundo();
            }
        }
    }
}
