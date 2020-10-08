using Pattern_DI_IoC.Interfaces;

namespace Pattern_DI_IoC.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        int IPedidoRepository.ObterTodos()
        {
            return 10;
        }
    }
}