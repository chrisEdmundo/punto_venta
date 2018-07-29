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
        public static List<products> buscarProductos()
        {
            List<products> Lista = new List<products>();
            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                MySqlCommand cm = new MySqlCommand("select c.nombres categoria, p.nombre, p.marca, p.descripcion, p.unidades, p.precio from categorias c, productos p where c.idCategoria = p.Categoria;", Conx);
                MySqlDataReader readr = cm.ExecuteReader();

                while (readr.Read())
                {
                    string categoria = readr.GetString(0);
                    string nombre = readr.GetString(1);
                    string marca = readr.GetString(2);
                    string descripcion = readr.GetString(3);
                    string unidades = readr.GetString(4);
                    string precio = readr.GetString(5);

                    products pProducto = new products();
                    pProducto.categoria = categoria;
                    pProducto.nombre = nombre;
                    pProducto.marca = marca;
                    pProducto.descripcion = descripcion;
                    pProducto.unidades = unidades;
                    pProducto.precio = precio;

                    Lista.Add(pProducto);
                }
                Conx.Close();
                return Lista;
            }
        }

        public static int agregar(string nombre, string marca, string descripcion, string unidades, string precio)
        {
            int retorno = 0;
            string n = encrip(nombre);
            string m = encrip(marca);
            string d = encrip(descripcion);
            string u = encrip(unidades);
            string p = encrip(precio);
            using (MySqlConnection Conn = conection.ObtenerConexion())
            {
                MySqlCommand Comando = new MySqlCommand(string.Format(
                    "Insert Into productos (nombre, marca, descripcion, unidades, precio) values ('{0}', '{1}','{2}','{3}','{4}')",
                    n, m, d, u, p), Conn);
                retorno = Comando.ExecuteNonQuery();
                Conn.Close();

            }
            return retorno;
        }

        public static string encrip(string cadena)
        {
            string key = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890";
            byte[] keyArray;
            byte[] Arreglo = UTF8Encoding.UTF8.GetBytes(cadena);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransfrom = tdes.CreateEncryptor();
            byte[] ArrayResultado = cTransfrom.TransformFinalBlock(Arreglo, 0, Arreglo.Length);
            tdes.Clear();

            return Convert.ToBase64String(Arreglo, 0, Arreglo.Length);
        }
        public string desencrip(string cadena)
        {
            string key = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890";
            byte[] keyArray;
            byte[] arreglo = Convert.FromBase64String(cadena);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransfrom = tdes.CreateDecryptor();
            byte[] ArrayResultado = cTransfrom.TransformFinalBlock(arreglo, 0, arreglo.Length);
            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(ArrayResultado);

        }


    }
}
