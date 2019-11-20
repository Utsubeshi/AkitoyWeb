using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkiToyWeb.Models
{
    public class Producto
    {
        public int idProducto { get; set; }
        public String Nombre { get; set; }
        public String Detalle { get; set; }
        public double PrecioCosto { get; set; }
        public double PrecioVenta { get; set; }
        public double Descuento { get; set; }
        public int Stock { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public double Peso { get; set; }
        public String Dimensiones { get; set; }
        public int idMarca { get; set; }
        public int idEstado { get; set; }
        public int idSerie { get; set; }
        public int idLinea { get; set; }
        public int idCategoria { get; set; }
        public bool Eliminado { get; set; }
        public bool EliminadorPor { get; set; }

        public Producto(int idProducto, string nombre, string detalle, double precioCosto, double precioVenta, double descuento, 
                        int stock, DateTime fechaIngreso, DateTime fechaLanzamiento, double peso, string dimensiones, int idMarca, 
                        int idEstado, int idSerie, int idLinea, int idCategoria, bool eliminado, bool eliminadorPor)
        {
            this.idProducto = idProducto;
            Nombre = nombre;
            Detalle = detalle;
            PrecioCosto = precioCosto;
            PrecioVenta = precioVenta;
            Descuento = descuento;
            Stock = stock;
            FechaIngreso = fechaIngreso;
            FechaLanzamiento = fechaLanzamiento;
            Peso = peso;
            Dimensiones = dimensiones;
            this.idMarca = idMarca;
            this.idEstado = idEstado;
            this.idSerie = idSerie;
            this.idLinea = idLinea;
            this.idCategoria = idCategoria;
            Eliminado = eliminado;
            EliminadorPor = eliminadorPor;
        }

        public Producto(string nombre, string detalle, double precioCosto, double precioVenta, double descuento,
                int stock, DateTime fechaIngreso, DateTime fechaLanzamiento, double peso, string dimensiones, int idMarca,
                int idEstado, int idSerie, int idLinea, int idCategoria, bool eliminado, bool eliminadorPor)
        {
            Nombre = nombre;
            Detalle = detalle;
            PrecioCosto = precioCosto;
            PrecioVenta = precioVenta;
            Descuento = descuento;
            Stock = stock;
            FechaIngreso = fechaIngreso;
            FechaLanzamiento = fechaLanzamiento;
            Peso = peso;
            Dimensiones = dimensiones;
            this.idMarca = idMarca;
            this.idEstado = idEstado;
            this.idSerie = idSerie;
            this.idLinea = idLinea;
            this.idCategoria = idCategoria;
            Eliminado = eliminado;
            EliminadorPor = eliminadorPor;
        }

        public Producto(int idProducto, string nombre, double precioVenta)
        {
            this.idProducto = idProducto;
            Nombre = nombre;
            PrecioVenta = precioVenta;
        }
    }

    public class ProductoDAO
    {
        ClsBD ClsBD = new ClsBD("cnCineStar");

    }

}