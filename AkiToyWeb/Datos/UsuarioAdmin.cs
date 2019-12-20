using AkiToyWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AkiToyWeb.Datos
{
    public class UsuarioAdmin
    {
        public IEnumerable<Usuario> Consultar()
        {
            using (AkiToyEntities contexto = new AkiToyEntities())
            {
                return contexto.Usuario.AsNoTracking().ToList();
            }
        }

        public Usuario Consultar(int id)
        {
            using (AkiToyEntities contexto = new AkiToyEntities())
            {
                return contexto.Usuario.FirstOrDefault(Usuario => Usuario.idUsuario == id);

            }
        }

        public void Guardar(Usuario usuario)
        {
            using(AkiToyEntities contexto  = new AkiToyEntities())
            {
                contexto.Usuario.Add(usuario);
                contexto.SaveChanges();
            }

        }

        public void Modificar(Usuario usuario)
        {
            using(AkiToyEntities contexto = new AkiToyEntities())
            {
                contexto.Entry(usuario).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(Usuario usuario)
        {
            using(AkiToyEntities contexto = new AkiToyEntities())
            {
                contexto.Entry(usuario).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}