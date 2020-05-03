using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexiones;
using System.Data;
using MySql.Data.MySqlClient;

namespace Clases
{
    public class Tipo
    {
        private int idTipo;
        private String detalle;

        public int IDTIPO { get => idTipo; set => idTipo = value; }
        public string DETALLE { get => detalle; set => detalle = value; }

        //================== Metodos estaticos de la clase ======================
        public static DataTable extraeTipos()
        {
            String cmd = "SELECT id_Tipo, detalle FROM tipos";
            // 
            DataSet ds = Accesos.datos(cmd); 
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        public static int guardaTipo(Tipo rep)
        {
            // almacenamos nuevo tipo. 
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO tipos(id_Tipo, detalle)" +
                " VALUES ('{0}','{1}')", rep.IDTIPO,rep.DETALLE, connn));

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }
    }
}
