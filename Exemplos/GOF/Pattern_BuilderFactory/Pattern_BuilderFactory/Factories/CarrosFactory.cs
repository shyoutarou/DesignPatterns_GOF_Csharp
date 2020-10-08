using Pattern_BuilderFactory.Builder;
using Pattern_BuilderFactory.Interface;
using Pattern_BuilderFactory.Model;
using Pattern_BuilderFactory.Service;

namespace Pattern_BuilderFactory.Factories
{
    public class CarrosFactory
    {
        public ConstruirVeiculo CriaVeiculos(string tipo)
        {
            Montadora montadora = new Montadora();
            ConstruirVeiculo cVeiculo = new ConstrutorMoto();

            switch (tipo)
            {
                case "Moto": cVeiculo = new ConstrutorMoto(); break;
                case "Carro": cVeiculo = new ConstrutorCarro(); break;
                default: cVeiculo = new ConstrutorCarro(); break;
            }

            montadora.Construir(cVeiculo);

            return cVeiculo;
        }
    }
}
