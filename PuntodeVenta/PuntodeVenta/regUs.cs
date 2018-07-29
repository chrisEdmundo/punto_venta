using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace PuntodeVenta
{
    class regUs
    {
        public static int agr(string nombre, string apaterno, string amaterno, string telefono, string contraseña)
        {
            int retorno = 0;
            string n = encrip(nombre);
            string ap = encrip(apaterno);
            string am = encrip(amaterno);
            string t = encrip(telefono);
            string c = encrip(contraseña);

            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                MySqlCommand Comando = new MySqlCommand(string.Format
                    ("insert into usuarios (nombre,apaterno,amaterno,telefono,password) values('{0}','{1}','{2}','{3}','{4}')", n, ap, am, t, c), Conx);
                retorno = Comando.ExecuteNonQuery();
                Conx.Close();
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

            return Convert.ToBase64String(Arreglo,0,Arreglo.Length);
        }
    }
}
