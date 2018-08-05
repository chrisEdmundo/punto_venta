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
                    ("insert into usuarios (nombre,apaterno,amaterno,telefono,password,id_status) values('{0}','{1}','{2}','{3}','{4}','{5}')", n, ap, am, t, c, s), Conx);
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
            string u = Encrip(unidades);
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
                    pProducto.unidades = acciones.Desencrip(unidades);
                    pProducto.precio = acciones.Desencrip(precio);
                    pProducto.codigo = codigo;

                    Lista.Add(pProducto);
                }
                Conx.Close();
                return Lista;
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
                    item.SubItems.Add(Desencrip(readr.GetString(4)));
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
                MySqlCommand cm = new MySqlCommand(string.Format("select nombre, password, id_status from usuarios where nombre='{0}' and password='{1}'", Encrip(usuario), Encrip(contraseña)), Conx);
                MySqlDataReader readr = cm.ExecuteReader();
                    while (readr.Read())
                    {
                        retorno = readr.GetInt32(2);
                    }
            }
            return retorno;
        }
        public static void Status(ComboBox cb)
        {
            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                MySqlCommand cm = new MySqlCommand("select nombre from status", Conx);
                MySqlDataReader readr = cm.ExecuteReader();
                while (readr.Read())
                {
                    cb.Items.Add(readr.GetString(0));
                }
                Conx.Close();
            }
        }
        public static void Vender(string codigo,ListView lista)
        {
            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                int cod = int.Parse(codigo);
                MySqlCommand cm = new MySqlCommand(string.Format("select nombre, marca, precio from productos where idProducto='{0}'",cod), Conx);
                MySqlDataReader readr = cm.ExecuteReader();
                while (readr.Read())
                {
                    ListViewItem item = new ListViewItem(Desencrip(readr.GetString(0)));
                    item.SubItems.Add(Desencrip(readr.GetString(1)));
                    item.SubItems.Add(Desencrip(readr.GetString(2)));
                    lista.Items.Add(item);
                }
                Conx.Close();
            }
        }
    }
}