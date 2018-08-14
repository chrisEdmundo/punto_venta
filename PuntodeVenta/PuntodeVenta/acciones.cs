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
        public static int Agregar_usuario(int status, string nombre, string apaterno, string amaterno, string telefono, string contraseña)
        {
            int retorno = 0;
            string n = acciones.Encrip(nombre);
            string ap = acciones.Encrip(apaterno);
            string am = acciones.Encrip(amaterno);
            string t = acciones.Encrip(telefono);
            string c = acciones.Encrip(contraseña);
            int s = status + 1;

            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                MySqlCommand Comando = new MySqlCommand(string.Format
                    ("insert into usuarios (nombre,apaterno,amaterno,telefono,password,status) values('{0}','{1}','{2}','{3}','{4}','{5}')", n, ap, am, t, c, s), Conx);
                retorno = Comando.ExecuteNonQuery();
                Conx.Close();
            }

            return retorno;
        }
        public static int Agregar_producto(int categoria, string nombre, string marca, string descripcion, string unidades, string precio)
        {
            int retorno = 0;
            int ctg = categoria + 1;
            string n = Encrip(nombre);
            string m = Encrip(marca);
            string d = Encrip(descripcion);
            string u = unidades;
            string p = Encrip(precio);
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
        public static int agregar_movimientos(int codigo, string nombre)
        {
            int retorno = 0;
            //
            /*
            int id_user = 0;
            string name = nombre;
            string apaterno = nombre;
            string amaterno = nombre;
            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                MySqlCommand cm = new MySqlCommand(string.Format("select idUsuario from usuarios where nombre='{0}' and apaterno='{1}' and amaterno='{2}'", Encrip(name), Encrip(apaterno), Encrip(amaterno)), Conx);
                MySqlDataReader readr = cm.ExecuteReader();
                while (readr.Read())
                {
                    id_user = int.Parse(Desencrip(readr.GetString(0)));
                }
            }*/
            //restar del inventario
            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                MySqlCommand Comando = new MySqlCommand(string.Format
                    ("update productos set unidades = unidades -1 where idProducto='{0}'", codigo), Conx);
                retorno = Comando.ExecuteNonQuery();
                Conx.Close();
            }

            //guardar movimientos
            /*
            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                MySqlCommand Comando = new MySqlCommand(string.Format
                    ("insert into movimientos (Producto, Usuario) values('{0}','{1}')", codigo, nombre), Conx);
                retorno = Comando.ExecuteNonQuery();
                Conx.Close();
            }
            */
            return retorno;
        }
        public static int Borrar(int codigo)
        {
            int retorno = 0;

            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                MySqlCommand Comando = new MySqlCommand(string.Format
                    ("delete from productos where idProducto='{0}'", codigo), Conx);
                retorno = Comando.ExecuteNonQuery();
                Conx.Close();
            }
            return retorno;
        }
        public static List<products> BuscarProductos()
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
                    pProducto.nombre = acciones.Desencrip(nombre);
                    pProducto.marca = acciones.Desencrip(marca);
                    pProducto.descripcion = acciones.Desencrip(descripcion);
                    pProducto.unidades = unidades;
                    pProducto.precio = acciones.Desencrip(precio);
                    pProducto.codigo = codigo;

                    Lista.Add(pProducto);
                }
                Conx.Close();
                return Lista;
            }
        }
        public static void busqueda_codigos(ListView lista)
        {
            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                MySqlCommand cm = new MySqlCommand(string.Format("select c.nombres categoria, p.nombre, p.marca,p.descripcion, p.precio, p.idProducto from categorias c, productos p where c.idCategoria = p.Categoria"), Conx);
                MySqlDataReader readr = cm.ExecuteReader();
                while (readr.Read())
                {
                    ListViewItem item = new ListViewItem(readr.GetString(0));
                    item.SubItems.Add(readr.GetString(5));
                    item.SubItems.Add(Desencrip(readr.GetString(1)));
                    item.SubItems.Add(Desencrip(readr.GetString(4)));
                    item.SubItems.Add(Desencrip(readr.GetString(3)));
                    item.SubItems.Add(Desencrip(readr.GetString(2)));
                    lista.Items.Add(item);
                }
                Conx.Close();
            }
        }
        public static void Categoria(ComboBox Combobox1)
        {

            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                MySqlCommand cm = new MySqlCommand("select * from categorias", Conx);
                MySqlDataReader readr = cm.ExecuteReader();
                while (readr.Read())
                {
                    Combobox1.Items.Add(readr.GetString(1));
                }
            }
        }
        public static string Desencrip(string cadena)
        {
            string codigo = "";
            char[] Arreglo = cadena.ToCharArray();

            for (int i = 0; i < cadena.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Arreglo[i] = (char)(Arreglo[i] - (char)3);
                }
                else
                {
                    Arreglo[i] = (char)(Arreglo[i] - (char)6);
                }
                codigo += Arreglo[i];
            }
            return codigo;
        }
        public static string Encrip(string cadena)
        {
            string codigo = "";
            char[] arreglo = cadena.ToCharArray();

            for (int i = 0; i < cadena.Length; i++)
            {
                if (i % 2 == 0)
                {
                    arreglo[i] = (char)(arreglo[i] + (char)3);
                }
                else
                {
                    arreglo[i] = (char)(arreglo[i] + (char)6);
                }
                codigo += arreglo[i];
            }
            return codigo;
        }
        public static void Inventario(ListView lista)
        {
            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                MySqlCommand cm = new MySqlCommand(string.Format("select c.nombres categoria, p.nombre, p.marca,p.descripcion, p.unidades, p.precio, p.idProducto from categorias c, productos p where c.idCategoria = p.Categoria"), Conx);
                MySqlDataReader readr = cm.ExecuteReader();
                while (readr.Read())
                {
                    ListViewItem item = new ListViewItem(readr.GetString(0));
                    item.SubItems.Add(Desencrip(readr.GetString(1)));
                    item.SubItems.Add(Desencrip(readr.GetString(2)));
                    item.SubItems.Add(Desencrip(readr.GetString(3)));
                    item.SubItems.Add(readr.GetString(4));
                    item.SubItems.Add(Desencrip(readr.GetString(5)));
                    item.SubItems.Add(readr.GetString(6));
                    lista.Items.Add(item);
                }
                Conx.Close();
            }
        }
        public static int Login(string usuario, string contraseña)
        {
            int retorno = 0;
            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                MySqlCommand cm = new MySqlCommand(string.Format("select nombre, password, status from usuarios where nombre='{0}' and password='{1}'", Encrip(usuario), Encrip(contraseña)), Conx);
                MySqlDataReader readr = cm.ExecuteReader();
                    while (readr.Read())
                    {
                        retorno = readr.GetInt32(2);
                    }
            }
            return retorno;
        }
        public static void usuario(string usuario, string contraseña, Label label1)
        {
            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                MySqlCommand cm = new MySqlCommand(string.Format("select nombre, apaterno, amaterno from usuarios where nombre='{0}' and password='{1}'", Encrip(usuario), Encrip(contraseña)), Conx);
                MySqlDataReader readr = cm.ExecuteReader();
                while (readr.Read())
                {
                    label1.Text = Desencrip(readr.GetString(0)) + " " + Desencrip(readr.GetString(1)) + " " + Desencrip(readr.GetString(2));
                }
            }
        }
        public static float Vender(string codigo,ListView lista,List<int> articulos)
        {
            float precio = 0;
            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                int cod = int.Parse(codigo);
                MySqlCommand cm = new MySqlCommand(string.Format("select nombre, marca, precio, idProducto from productos where idProducto='{0}'",cod), Conx);
                MySqlDataReader readr = cm.ExecuteReader();
                while (readr.Read())
                {
                    ListViewItem item = new ListViewItem(Desencrip(readr.GetString(0)));
                    item.SubItems.Add(Desencrip(readr.GetString(1)));
                    item.SubItems.Add(Desencrip(readr.GetString(2)));
                    lista.Items.Add(item);
                    precio = float.Parse(Desencrip(readr.GetString(2)));
                    articulos.Add(int.Parse(readr.GetString(3)));
                }
                Conx.Close();
            }
            return precio;
        }
    }
}
