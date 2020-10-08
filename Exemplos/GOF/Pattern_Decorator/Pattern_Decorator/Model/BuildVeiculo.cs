
namespace Pattern_Decorator.Model
{
    public abstract class BuildVeiculo
    {
        protected Veiculo veiculo;

        public Veiculo Veiculo
        {
            get { return veiculo; }
            set { veiculo = value; }
        }

        public abstract void ContruirChassi();
        public abstract void ConstruirMotor();
        public abstract void ConstruirRodas();
        public abstract void ConstruirPortas();
    }
}
