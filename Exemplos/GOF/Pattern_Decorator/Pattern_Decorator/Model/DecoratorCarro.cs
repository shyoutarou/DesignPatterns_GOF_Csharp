using Pattern_Decorator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Decorator.Decorator
{
    public abstract class DecoratorCarro : Veiculo
    {
        double _preco = -1;
        string _descricao = "Decorador Abstrato de Carro";

        public override double Preco
        {
            get { return _preco; }
        }
        public override string Descricao
        {
            get { return _descricao; }
        }
    }
}
