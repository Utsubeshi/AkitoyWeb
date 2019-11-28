using AkiToyWeb.Models;
using System.Web.Mvc;

namespace AkiToyWeb.Controllers
{
    public class AdminController : Controller
    {
        private ProductoDAO productoDAO;

        public AdminController()
        {
            productoDAO = new ProductoDAO();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaProducto()
        {
            var model = productoDAO.VerProductos();
            return View(model);
        }
    }
}