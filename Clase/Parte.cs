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
    public class Parte
    {
        private int idParte;
        private String fecha;
        private int idTipo;
        private int idProced;
        private String detalle;
        private String estado;

        public int IDPARTE { get => idParte; set => idParte = value; }
        public string FECHA { get => fecha; set => fecha = value; }
        public int IDTIPO { get => idTipo; set => idTipo = value; }
        public int IDPROCED { get => idProced; set => idProced = value; }
        public string DETALLE { get => detalle; set => detalle = value; }
        public string ESTADO { get => estado; set => estado = value; }

        //==================  Métodos estáticos de la clase ===============================

        public static DataTable datoParte(int nick)
        {
            String cmd = "SELECT id_Parte,fecha,id_Tema,id_Prov," +
                "detalle,estado FROM partediario WHERE id_Parte=" + nick;
            // el dato NICK recibido es la identificación del parte diario (int)
            DataSet ds = Accesos.datos(cmd); //accesos  es la clase de lectura de datos
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        public static DataTable extraeParte(String est)
        {
            String cmd = "SELECT PD.id_Parte,PD.fecha,TE.tema,PR.nombre,PD.detalle " +
                         "FROM partediario as PD INNER JOIN temas as TE on pd.id_Tema = TE.id_Tema " +
                         "INNER JOIN proveedor as PR on pd.id_Prov = PR.id_Prov WHERE estado ='" + est + "'";
            // el dato est recibido es dato de estado del parte diario (string)
            DataSet ds = Accesos.datos(cmd); //accesos  es la clase de lectura de datos
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        public static DataTable extraeSinEstado()
        {
            String cmd = "SELECT PD.id_Parte,PD.fecha,TE.tema,PR.nombre,PD.detalle,PD.estado " +
                         "FROM partediario as PD INNER JOIN temas as TE on pd.id_Tema = TE.id_Tema " +
                         "INNER JOIN proveedor as PR on pd.id_Prov = PR.id_Prov";
            // extraemos todos los partes diarios sin discriminar
            DataSet ds = Accesos.datos(cmd); //accesos  es la clase de lectura de datos
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        public static DataTable PartePorTema(int idtema)
        {
            String cmd = "SELECT id_Parte,fecha,detalle,estado " +
                         "FROM partediario WHERE id_Tema ='" + idtema + "'";

            // el dato idtema recibido es el ID_TEMA del registro del parte diario (int)
            DataSet ds = Accesos.datos(cmd); //accesos  es la clase de lectura de datos
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        public static DataTable PartePorProcedencia(int idProc)
        {
            String cmd = "SELECT id_Parte,fecha,detalle,estado " +
                         "FROM partediario WHERE id_Prov ='" + idProc + "'";

            // el dato idProc recibido es el ID_PROCEDENCIA del registro del parte diario (int)
            DataSet ds = Accesos.datos(cmd); //accesos  es la clase de lectura de datos
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }
        public static DataTable partes()
        {
            String cmd = "SELECT id_Parte, fecha, id_Tema, id_Prov," +
                "detalle,estado FROM partediario";
            // Extrae la totalidad de los registros de partes diarios
            DataSet ds = Accesos.datos(cmd); //accesos  es la clase de lectura de datos
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        public static int guardaParte(Parte rep)
        {
            // almacenamos nuevo parte diario. Incluso el idParte tiene valor 0
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO partediario(id_Parte, fecha, id_Tema, id_Prov,detalle,estado)" +
                " VALUES ({0},'{1}',{2},{3},'{4}','{5}')", rep.IDPARTE, rep.FECHA, rep.IDTIPO, rep.IDPROCED, rep.DETALLE, rep.ESTADO), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }

        public static int modificaParte(Parte rep, int orden)
        {
            // aca modificamos el detalle del parte diario mientras está pendiente
            // o solamente modificamos el estado para pasarlo de pendiente a otro cerrado
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("UPDATE partediario SET id_Parte='{0}',detalle='{1}',estado='{2}' WHERE id_Parte='{3}'",
                +rep.IDPARTE, rep.DETALLE, rep.ESTADO, orden), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }

        public static int modificaEstado(Parte rep, int orden)
        {
            // aca solamente modificamos el estado de un parte diario una vez que dejó de estar pendiente
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("UPDATE partediario SET id_Parte='{0}',detalle='{1}',estado='{2}' WHERE id_Parte='{3}'",
                +rep.IDPARTE, rep.DETALLE, rep.ESTADO, orden), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }
    }
}
