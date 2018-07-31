using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntodeVenta
{
    public class products
    {
        public String categoria { get; set; }
        public String nombre { get; set; }
        public String marca { get; set; }
        public String descripcion { get; set; }
        public String unidades { get; set; }
        public String precio { get; set; }
        public String codigo { get; set; }

        public products() { }

        public products(String categoria, String nombre, String marca, String descripcion, String unidades, String precio, String codigo)
        {
            this.categoria = categoria;
            this.nombre = nombre;
            this.marca = marca;
            this.descripcion = descripcion;
            this.unidades = unidades;
            this.precio = precio; 
            this.codigo = codigo;
        }
    }
    public class articulos
    {
        public String nombre { get; set; }
        public String marca { get; set; }
        public String precio { get; set; }

        public articulos() { }

        public articulos(String nombre, String marca,String precio)
        {
            this.nombre = nombre;
            this.marca = marca;
            this.precio = precio;
        }
    }
}
