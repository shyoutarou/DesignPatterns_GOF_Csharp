using Pattern_DI_IoC.Interfaces;
using System.Web.Mvc;

namespace Pattern_DI_IoC.Controllers
{
    public class PedidosController : Controller
{

    private IPedidoRepository _pedidoRepositorio;

    public PedidosController(IPedidoRepository pedidoRepositorio)
    {
        _pedidoRepositorio = pedidoRepositorio;
    }

    //
    // GET: /pedidos/
    public ActionResult Index()
    {
        var pedidos = _pedidoRepositorio.ObterTodos();

        return View(pedidos);
    }


    //    // GET: Pedidos
    //    public ActionResult Index()
    //{
    //    var pedidoRepositorio = new PedidoRepository();

    //    var pedidos = pedidoRepositorio.ObterTodos();

    //    ViewBag.Message = "Your pedidos.";
    //    return View(pedidos);
    //}
}
}