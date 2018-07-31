using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntodeVenta
{
    class acciones
    {
        public static void buscar(DataGridView dataGridView1, ListBox listBox1)
        {
            dataGridView1.DataSource = acciones.buscarProductos();
            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                MySqlCommand cm = new MySqlCommand("select * from categorias", Conx);
                MySqlDataReader readr = cm.ExecuteReader();
                while (readr.Read())
                {
                    listBox1.Items.Add(readr.GetString(1));
                }
            }
        }
        public static List<products> buscarProductos()
        {
            List<products> Lista = new List<products>();
            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                MySqlCommand cm = new MySqlCommand("select c.nombres categoria, p.nombre, p.marca, p.descripcion, p.unidades, p.precio, p.idProducto from categorias c, productos p where c.idCategoria = p.Categoria;", Conx);
                MySqlDataReader readr = cm.ExecuteReader();

                while (readr.Read())
                {
                    string categoria = readr.GetString(0);
                    string nombre = readr.GetString(1);
                    string marca = readr.GetString(2);
                    string descripcion = readr.GetString(3);
                    string unidades = readr.GetString(4);
                    string precio = readr.GetString(5);
                    string codigo = readr.GetString(6);

                    products pProducto = new products();
                    pProducto.categoria = categoria;
                    pProducto.nombre = acciones.desencrip(nombre);
                    pProducto.marca = acciones.desencrip(marca);
                    pProducto.descripcion = acciones.desencrip(descripcion);
                    pProducto.unidades = acciones.desencrip(unidades);
                    pProducto.precio = acciones.desencrip(precio);
                    pProducto.codigo = codigo;

                    Lista.Add(pProducto);
                }
                Conx.Close();
                return Lista;
            }
        }
        public static int agregar(int categoria, string nombre, string marca, string descripcion, string unidades, string precio)
        {
            int retorno = 0;
            int ctg = categoria + 1;
            string n = encrip(nombre);
            string m = encrip(marca);
            string d = encrip(descripcion);
            string u = encrip(unidades);
            string p = encrip(precio);
            using (MySqlConnection Conn = conection.ObtenerConexion())
            {
                MySqlCommand Comando = new MySqlCommand(string.Format(
                    "Insert Into productos (Categoria, nombre, marca, descripcion, unidades, precio) values ('{0}', '{1}','{2}','{3}','{4}','{5}')",
                    ctg, n, m, d, u, p), Conn);
                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            return retorno;
        }
        public static List<articulos> vender(string codigo)
        {
            List<articulos> Lista = new List<articulos>();
            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                int cod = int.Parse(codigo);
                MySqlCommand cm = new MySqlCommand(string.Format("select nombre, marca, precio from productos where idProducto='{0}'",cod), Conx);
                MySqlDataReader readr = cm.ExecuteReader();

                while (readr.Read())
                {
                    string nombre = acciones.desencrip(readr.GetString(0));
                    string marca = acciones.desencrip(readr.GetString(1));
                    string precio = acciones.desencrip(readr.GetString(2));

                    articulos pProducto = new articulos();
                    pProducto.nombre = nombre;
                    pProducto.marca = marca;
                    pProducto.precio = precio;

                    Lista.Add(pProducto);
                }
                Conx.Close();
                return Lista;
            }
        }

        public static string encrip(string cadena)
        {
            string codigo = "";
            char[] arreglo = cadena.ToCharArray();

            for( int i=0; i < cadena.Length; i++)
            {
                arreglo[i] = (char)(arreglo[i] + (char)11);
                codigo += arreglo[i];
            }
            return codigo;

        }
        public static string desencrip(string cadena)
        {
            string codigo = "";
            char[] Arreglo = cadena.ToCharArray();

            for (int i = 0; i < cadena.Length; i++)
            {
                Arreglo[i] = (char)(Arreglo[i] - (char)11);
                codigo += Arreglo[i];
            }
            return codigo;
        }
        public static void borrar (DataGridViewSelectedRowCollection dgw)
        {
            
        }
    }
}