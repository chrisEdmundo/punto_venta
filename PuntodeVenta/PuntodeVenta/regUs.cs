using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace PuntodeVenta
{
    class regUs
    {
        public static int agr(string nombre, string apaterno, string amaterno, string telefono, string contraseña)
        {
            int retorno = 0;
            string n = nombre;
            string ap = apaterno;
            string am = amaterno;
            string t = telefono;
            string c = contraseña;
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
