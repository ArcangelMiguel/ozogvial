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
    public class Tema
    {
        private int idTema;
        private String detalle;

        public int IDTEMA { get => idTema; set => idTema = value; }
        public string DETALLE { get => detalle; set => detalle = value; }

        //================== Metodos estaticos de la clase ======================
        public static DataTable extraeTEMA()
        {
            String cmd = "SELECT id_Tema, tema FROM temas";
            // 
            DataSet ds = Accesos.datos(cmd); 
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        public static int guardaTema(Tema rep)
        {
            // almacenamos nuevo tipo. 
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO temas(id_Tema, tema)" +
                " VALUES ('{0}','{1}')", rep.IDTEMA,rep.DETALLE, connn));

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }
    }
}
