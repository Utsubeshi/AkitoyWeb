using AkiToyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkiToyWeb.Datos
{
    public class LineaAdmin
    {
        public SelectList ComboBoxLineas()
        {
            using (AkiToyEntities contexto = new AkiToyEntities())
                return new SelectList(contexto.Linea.AsNoTracking().ToList(), "idLinea", "Detalle");
        }
    }
}