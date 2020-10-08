using Pattern_Decorator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Decorator.Decorator
{

public class Carro_Turbo : DecoratorCarro
{
    double _preco = 9500.50;
    string _descricao = "Turbo, ";
    Veiculo _carro;

    public Carro_Turbo(Veiculo carro)
    {
        _carro = carro;
    }

    public override double Preco
    {
        get { return _carro.Preco + _preco; }
    }

    public override string Descricao
    {
        get { return _carro.Descricao + _descricao; }
    }
}
}
