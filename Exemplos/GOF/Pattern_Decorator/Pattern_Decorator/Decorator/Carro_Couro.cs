using Pattern_Decorator.Model;

namespace Pattern_Decorator.Decorator
{

public class Carro_Couro : DecoratorCarro
{
    double _preco = 4250.25;
    string _descricao = "Banco de Couros, ";
    Veiculo _carro;

    public Carro_Couro(Veiculo carro)
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
