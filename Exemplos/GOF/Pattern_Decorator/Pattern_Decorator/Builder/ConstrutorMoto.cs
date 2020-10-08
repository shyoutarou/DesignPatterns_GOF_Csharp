using Pattern_Decorator.Model;

namespace Pattern_Decorator.Builder
{
    public class ConstrutorMoto : BuildVeiculo
    {
        public override void ContruirChassi()
        {
            veiculo = new Veiculo("Moto");
            veiculo["chassi"] = "Chassi da Moto";
        }

        public override void ConstruirMotor()
        {
            veiculo["motor"] = "500 cc";
        }

        public override void ConstruirRodas()
        {
            veiculo["rodas"] = "2";
        }

        public override void ConstruirPortas()
        {
            veiculo["portas"] = "0";
        }
    }
}
