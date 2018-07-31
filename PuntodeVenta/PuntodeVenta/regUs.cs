using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace PuntodeVenta
{
    class regUs
    {
        public static int login(string usuario, string contraseña)
        {
            int retorno = 0;
            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                MySqlCommand cm = new MySqlCommand(string.Format("select nombre, password from usuarios"), Conx);
                MySqlDataReader readr = cm.ExecuteReader();

                while (readr.Read())
                {
                    if (acciones.encrip(usuario).Equals(readr.GetString(0)) && acciones.encrip(contraseña).Equals(readr.GetString(1)))
                    {
                        retorno = 1;
                    }
                    else retorno = 0;
                }
            }
            return retorno;
        }
        public static int agr(string nombre, string apaterno, string amaterno, string telefono, string contraseña)
        {
            int retorno = 0;
            string n = acciones.encrip(nombre);
            string ap = acciones.encrip(apaterno);
            string am = acciones.encrip(amaterno);
            string t = acciones.encrip(telefono);
            string c = acciones.encrip(contraseña);

            using (MySqlConnection Conx = conection.ObtenerConexion())
            {
                MySqlCommand Comando = new MySqlCommand(string.Format
                    ("insert into usuarios (nombre,apaterno,amaterno,telefono,password) values('{0}','{1}','{2}','{3}','{4}')", n, ap, am, t, c), Conx);
                retorno = Comando.ExecuteNonQuery();
                Conx.Close();
            }
            

            return retorno;
        }
    }
}
