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
            //  server=localhost; database=ozogvial; Uid=root; pwd='MaImEs3321'
            //  server=192.168.0.103; database=ozogvial; Uid=miguel; pwd='1234'

            MySqlConnection conn = new MySqlConnection("server=192.168.0.103; database=ozogvial; Uid=miguel; pwd='1234';");
            conn.Open();

            DataSet DS = new DataSet();
            MySqlDataAdapter DA = new MySqlDataAdapter(sql, conn);
            DA.Fill(DS);

            conn.Close();

            return DS;
        }

        public static MySqlConnection UnaConexion()
        {
            MySqlConnection conx = new MySqlConnection("server=192.168.0.103; database=ozogvial; Uid=miguel; pwd='1234';");
            conx.Open();

            return conx;
        }
    }
}
