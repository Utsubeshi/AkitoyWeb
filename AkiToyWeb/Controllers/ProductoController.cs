using AkiToyWeb.Datos;
using AkiToyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkiToyWeb.Controllers
{
    public class ProductoController : Controller
    {
        private ProductoAdmin productoAdmin = new ProductoAdmin();
        private MarcaAdmin marca = new MarcaAdmin();
        private EstadoAdmin estado = new EstadoAdmin();
        private CategoriaAdmin categoria = new CategoriaAdmin();
        private LineaAdmin linea = new LineaAdmin();
        private SerieAdmin serie = new SerieAdmin();

        // GET: Producto
        public ActionResult Index()
        {
           return View(productoAdmin.Consultar());
        }

        public ActionResult Detalle(int id)
        {
            //return View(productoAdmin.Consultar(id));
            using (AkiToyEntities contexto = new AkiToyEntities())
            {
                var model = productoAdmin.Consultar(id);
                return View(model);
            }            
        }

        public ActionResult Crear()
        {
            ViewBag.Series = serie.ComboBoxSeries();
            ViewBag.Lineas = linea.ComboBoxLineas();
            ViewBag.Estados = estado.ComboBoxEstados();
            ViewBag.Categorias = categoria.ComboBoxCategorias();
            ViewBag.Marcas = marca.ComboBoxMarcas();
            /*ViewData["fechaActual"] = DateTime.Now.ToString();*/
            return View();
            
                
        }

        public ActionResult Guardar(Producto producto)
        {
            productoAdmin.Guardar(producto);
            
            return View("Index" , productoAdmin.Consultar());
        }

        public ActionResult Editar(int id)
        {
            ViewBag.Series = serie.ComboBoxSeries();
            ViewBag.Lineas = linea.ComboBoxLineas();
            ViewBag.Estados = estado.ComboBoxEstados();
            ViewBag.Categorias = categoria.ComboBoxCategorias();
            ViewBag.Marcas = marca.ComboBoxMarcas();
            return View(productoAdmin.Consultar(id));
        }

        public ActionResult Modificar(Producto producto)
        {
            productoAdmin.Modificar(producto);
            return View("Index", productoAdmin.Consultar());
        }

        public ActionResult Eliminar(int id)
        {
            if (id != null)
            {
                Producto producto = productoAdmin.Consultar(id);
                productoAdmin.Eliminar(producto);
            }
            return View("Index", productoAdmin.Consultar());
            
        }

    }

}