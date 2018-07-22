using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace PuntodeVenta
{
    class conection
    {
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnectionStringBuilder c = new MySqlConnectionStringBuilder();
            c.Server = "localhost";
            c.UserID = "root";
            c.Password = "chris317";
            c.Database = "punto_venta";
            c.SslMode = MySqlSslMode.None;
            MySqlConnection Conx = new MySqlConnection(c.ToString());
            Conx.Open();

            return Conx;
        }
    }
}
