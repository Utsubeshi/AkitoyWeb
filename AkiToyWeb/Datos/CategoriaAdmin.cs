using AkiToyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkiToyWeb.Datos
{
    public class CategoriaAdmin
    {
        public SelectList ComboBoxCategorias()
        {
            using (AkiToyEntities contexto = new AkiToyEntities())
                return new SelectList(contexto.Categoria.AsNoTracking().ToList(), "idCategoria", "Detalle");
        }
    }
}