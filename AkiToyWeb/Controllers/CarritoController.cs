using AkiToyWeb.Datos;
using AkiToyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkiToyWeb.Controllers
{
    public class CarritoController : Controller
    {
        private ProductoAdmin productoAdmin = new ProductoAdmin();

        // GET: Carrito
        
        public ActionResult Agregar(int id)
        {
            Producto producto = productoAdmin.Consultar(id);
            List<Producto> lstProductos = null;

            if (Session["Carrito"] == null)
            {
                lstProductos = new List<Producto>();
            }
            else
            {
                lstProductos = (List<Producto>)Session["Carrito"];
            }

            lstProductos.Add(producto);

            Session["Carrito"] = lstProductos;
            Session["Cantidad"] = lstProductos.Count;
            Session["Total"] = lstProductos.Sum(x => x.PrecioVenta);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult VerCarrito()
        {
            return View((List<Producto>)Session["Carrito"]);
        }

        public ActionResult Eliminar(int id)
        {
            List<Producto> lstProductos = (List<Producto>)Session["Carrito"];
            var producto = lstProductos.Find(p => p.idProducto == id);
            lstProductos.Remove(producto);

            Session["Carrito"] = lstProductos;
            Session["Cantidad"] = lstProductos.Count;
            Session["Total"] = lstProductos.Sum(x => x.PrecioVenta);
            return View("VerCarrito", (List<Producto>)Session["Carrito"]);
        }
    }
}