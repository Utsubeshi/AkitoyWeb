using AkiToyWeb.Models;
using System.Web.Mvc;

namespace AkiToyWeb.Controllers
{
    public class HomeController : Controller
    {
        private ProductoDAO productoDAO;

        public HomeController()
        {
            productoDAO = new ProductoDAO();
        }
        // GET: Home
        public ActionResult Index()
        {
            //List<Producto> productos = productoDAO.GetListaIndex();
            var model = productoDAO.GetListaIndex();
            return View(model);
        }
    }
}