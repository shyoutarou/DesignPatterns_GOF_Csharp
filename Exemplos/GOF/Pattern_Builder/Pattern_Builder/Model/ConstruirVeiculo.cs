
namespace Pattern_Builder.Model
{
    public abstract class ConstruirVeiculo
    {
        protected Veiculo veiculo;

        public Veiculo Veiculo
        {
            get { return veiculo; }
        }

        public abstract void ContruirChassi();
        public abstract void ConstruirMotor();
        public abstract void ConstruirRodas();
        public abstract void ConstruirPortas();
    }
}
