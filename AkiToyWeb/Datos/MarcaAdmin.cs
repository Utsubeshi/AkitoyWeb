using AkiToyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkiToyWeb.Datos
{
    public class MarcaAdmin
    {
        public SelectList ComboBoxMarcas()
        {
            using (AkiToyEntities contexto = new AkiToyEntities())
            return new SelectList(contexto.Marca.AsNoTracking().ToList(), "idMarca", "Detalle");
        }
    }
}