using AkiToyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkiToyWeb.Datos
{
    public class EstadoAdmin
    {
        public SelectList ComboBoxEstados()
        {
            using (AkiToyEntities contexto = new AkiToyEntities())
                return new SelectList(contexto.Estado.AsNoTracking().ToList(), "idEstado", "Detalle");
        }
    }
}