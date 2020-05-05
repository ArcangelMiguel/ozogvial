using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Conexiones
{
    public class Accesos
    {
        public static DataSet datos(string sql)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost; database=ozogvial; Uid=root; pwd='MaImEs3321';");
            conn.Open();

            DataSet DS = new DataSet();
            MySqlDataAdapter DA = new MySqlDataAdapter(sql, conn);
            DA.Fill(DS);

            conn.Close();

            return DS;
        }

        public static MySqlConnection UnaConexion()
        {
            MySqlConnection conx = new MySqlConnection("server=localhost; database=ozogvial; Uid=root; pwd='MaImEs3321';");
            conx.Open();

            return conx;
        }
    }
}
