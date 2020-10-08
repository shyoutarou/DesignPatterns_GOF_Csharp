using Pattern_Builder.Model;

namespace Pattern_Builder.Builder
{
    public class ConstrutorCarro : ConstruirVeiculo
    {
        public override void ContruirChassi()
        {
            veiculo = new Veiculo("Carro");
            veiculo["chassi"] = "Chassi do Carro";
        }

        public override void ConstruirMotor()
        {
            veiculo["motor"] = "2500cc";
        }

        public override void ConstruirRodas()
        {
            veiculo["rodas"] = "4";
        }

        public override void ConstruirPortas()
        {
            veiculo["portas"] = "4";
        }
    }
}
