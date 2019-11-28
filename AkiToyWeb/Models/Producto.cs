using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public String Ingreso { get; set; }
        public DateTime FechaLanzamiento { get; set; }

        public String Lanzamiento { get; set; }
        public double Peso { get; set; }
        public String Dimensiones { get; set; }
        public int idMarca { get; set; }
        public int idEstado { get; set; }
        public int idSerie { get; set; }
        public int idLinea { get; set; }
        public int idCategoria { get; set; }

        public String Marca { get; set; }
        public String Estado { get; set; }
        public String Serie { get; set; }
        public String Linea { get; set; }
        public String Categoria { get; set; }
        public bool Eliminado { get; set; }
        public bool EliminadorPor { get; set; }
        /*
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
        */

        public Producto() { }

        public Producto(String[] registro)
        {
            if (registro.Length == 4) {
                this.idProducto = Int32.Parse(registro[0]);
                this.Nombre = registro[1];
                this.PrecioVenta = double.Parse(registro[2]);
            } else if(registro.Length == 15)
            {
                this.idProducto = Int32.Parse(registro[0]);
                this.Nombre = registro[1];
                this.Detalle = registro[2];
                this.PrecioCosto = Double.Parse(registro[3]);
                this.PrecioVenta = Double.Parse(registro[4]);
                this.Stock = Int32.Parse(registro[5]);
                this.Ingreso = registro[6];
                this.Lanzamiento = registro[7];
                this.Peso = Double.Parse(registro[8]);
                this.Dimensiones = registro[9];
                this.Marca = registro[10];
                this.Estado = registro[11];
                this.Serie = registro[12];
                this.Linea = registro[13];
                this.Categoria = registro[14];
            }
        }

        public List<Producto> GetLista(DataTable dt)
        {
            if (dt.Rows.Count == 0) return null;
            List<Producto> productos = new List<Producto>();
            foreach (DataRow dr in dt.Rows)
                productos.Add(new Producto(System.Array.ConvertAll(dr.ItemArray, x => x.ToString().Trim())));
            return productos;
        }
    }

    public class ProductoDAO
    {
        ClsBD ClsBD = new ClsBD("AkiToy");

        public List<Producto> GetListaIndex()
        {
            ClsBD.Sentencia("exec ListaDePortada");
            return new Producto().GetLista(ClsBD.GetDataTable());
        }

        public List<Producto> VerProductos()
        {
            ClsBD.Sentencia("exec sp_ListaProductos 0");
            return new Producto().GetLista(ClsBD.GetDataTable());
        }

        /*
        public DataTable VerProductos() //obtener datatable de tabla
        {
            ClsBD.Sentencia("exec sp_ListaProductos 0");
            return ClsBD.GetDataTable();
        } 
        
        public void GetComboProductos()
        {
            ClsBD.Sentencia("select idProducto, Nombre from Producto");
            ClsBD.getDropDownList(lista);
        }
        */
    }
}