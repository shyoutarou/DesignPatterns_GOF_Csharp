using Pattern_Factory.Interface;
using Pattern_Factory.Service;

namespace Pattern_Factory.Factories
{


    public class AloFactory
    {
        public IAloMundo CriaAloMundo(string idioma)
        {
            switch (idioma)
            {
                case "en": return new EnglishAloMundo();
                case "sp": return new SpanishAloMundo();
                case "de": return new GermanAloMundo();
                default: return new GermanAloMundo();
            }
        }
    }
}
