using AkiToyWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AkiToyWeb.Datos
{
    public class ProductoAdmin
    {
        public IEnumerable<Producto> Consultar()
        {
            using (AkiToyEntities contexto = new AkiToyEntities())
            {
                //return contexto.Producto.AsNoTracking().ToList();
                return contexto.Producto.Select(x => new { 
                    idProducto = x.idProducto, 
                    Nombre = x.Nombre, 
                    Detalle = x.Detalle, 
                    Marca = x.Marca,
                    Serie = x.Serie,
                    Linea =x.Linea,
                    Categoria = x.Categoria,
                    PrecioCosto = x.PrecioCosto, 
                    PrecioVenta = x.PrecioVenta,
                    Stock = x.Stock,
                    Estado = x.Estado }).ToList()
                    .Select(x => new Producto { 
                        idProducto = x.idProducto, 
                        Nombre = x.Nombre, 
                        Detalle = x.Detalle, 
                        Marca = x.Marca, 
                        Serie = x.Serie,
                        Linea = x.Linea,
                        Categoria = x.Categoria,
                        PrecioCosto = x.PrecioCosto, 
                        PrecioVenta = x.PrecioVenta,
                        Stock = x.Stock,
                        Estado = x.Estado }).ToList();
            }
        }

        public Producto Consultar(int id)
        {
            using (AkiToyEntities contexto = new AkiToyEntities())
            {
                return contexto.Producto.Include("Estado")
                    .Include("Marca")
                    .Include("Categoria")
                    .Include("Serie")
                    .Include("Linea")
                    .FirstOrDefault(Producto => Producto.idProducto == id);

            }
        }

        public void Guardar(Producto producto)
        {
            using (AkiToyEntities contexto = new AkiToyEntities())
            {
                contexto.Producto.Add(producto);
                contexto.SaveChanges();
                producto = null;
            }
        }

        public void Modificar(Producto producto)
        {
            using (AkiToyEntities contexto = new AkiToyEntities())
            {
                contexto.Entry(producto).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(Producto producto)
        {
            using (AkiToyEntities contexto = new AkiToyEntities())
            {
                contexto.Entry(producto).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}