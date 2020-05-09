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
    public class Obra
    {
        private int idObra;
        private String nombre;
        private String alias;
        private String comitente;

        public int IDOBRA { get => idObra; set => idObra = value; }
        public string NOMBRE { get => nombre; set => nombre = value; }
        public string ALIAS { get => alias; set => alias = value; }
        public string COMITENTE { get => comitente; set => comitente = value; }

        //================== Metodos estaticos de la clase ======================
        public static DataTable extraeObra()
        {
            String cmd = "SELECT id_Obra, alias FROM obra";
            // 
            DataSet ds = Accesos.datos(cmd);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        public static int guardaObra(Obra rep)
        {
            // almacenamos nuevo proveedor. 
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO obra(id_Obra, nombre,alias,comitente)" +
                " VALUES ('{0}','{1}','{2}','{3}')", rep.IDOBRA, rep.NOMBRE,rep.ALIAS, rep.COMITENTE), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }
    }
}
