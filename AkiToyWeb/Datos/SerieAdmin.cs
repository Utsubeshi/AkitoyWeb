using AkiToyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkiToyWeb.Datos
{
    public class SerieAdmin
    {
        public SelectList ComboBoxSeries()
        {
            using( AkiToyEntities contexto = new AkiToyEntities())
            {
                return new SelectList(contexto.Serie.AsNoTracking().ToList(), "idSerie", "Detalle" );
            }
        }
    }
}