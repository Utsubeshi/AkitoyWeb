﻿using AkiToyWeb.Models;
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
            var model = productoDAO.GetListaIndex();
            return View(model);
        }
    }
}