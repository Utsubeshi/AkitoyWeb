using AkiToyWeb.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkiToyWeb.Controllers
{
    public class HomeController : Controller
    {
        ProductoAdmin productoAdmin = new ProductoAdmin();
        // GET: Home
        public ActionResult Index()
        {
            return View(productoAdmin.Consultar());
        }
    }
}