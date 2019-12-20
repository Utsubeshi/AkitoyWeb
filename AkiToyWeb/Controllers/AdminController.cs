using AkiToyWeb.Datos;
using AkiToyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkiToyWeb.Controllers
{
    public class AdminController : Controller
    {
        UsuarioAdmin usuarioAdmin = new UsuarioAdmin();
        // GET: Admin
        public ActionResult Index()
        {
            return View(usuarioAdmin.Consultar());
        }

        public ActionResult Editar(int id)
        {
            return View(usuarioAdmin.Consultar(id));
        }

        public ActionResult Guardar(Usuario usuario)
        {
            usuarioAdmin.Guardar(usuario);
            return View("Crear", usuario);
        }

        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult Eliminar(int id)
        {
            Usuario usuario = usuarioAdmin.Consultar(id);
            usuarioAdmin.Eliminar(usuario);
            return View("Index", usuarioAdmin.Consultar());
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            using(AkiToyEntities contexto = new AkiToyEntities())
            {
                try { 
                var user = contexto.Usuario.FirstOrDefault(x => x.Email == usuario.Email && x.Pass == usuario.Pass);
                
                if (user != null)
                {
                    Session["idUsuario"] = user.idUsuario.ToString();
                    Session["nombreUsuario"] = user.Nombre.ToString() + " " + user.Paterno.ToString();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Correo o password incorrectos.");
                }
                return View();
                }
                finally { }
            }
        }
    }
}