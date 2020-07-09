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
    public class Recibo
    {
        private int idRecibo;
        private int numero;
        private String fecha;
        private int idEmpleado;
        private float monto;
        private String concepto;
        private int estado;
        private int idObra;

        public int IDRECIBO { get => idRecibo; set => idRecibo = value; }
        public int NUMERO { get => numero; set => numero = value; }
        public String FECHA { get => fecha; set => fecha = value; }
        public int IDEMPLEADO { get => idEmpleado; set => idEmpleado = value; }
        public float MONTO { get => monto; set => monto = value; }
        public String CONCEPTO { get => concepto; set => concepto = value; }
        public int ESTADO { get => estado; set => estado = value; }
        public int IDOBRA { get => idObra; set => idObra = value; }


        //================== Metodos estaticos de la clase ======================
        public static DataTable extraeRecibos()
        {
            String cmd = "SELECT R.id_Recibo,R.numero,R.fecha,E.nombre,R.monto,R.concepto, R.estado " +
                         "FROM recibos as R INNER JOIN empleados as E on R.id_Empleado = E.id_Empleado ";
            DataSet ds = Accesos.datos(cmd);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        public static int guardaRecibo(Recibo rep)
        {
            // almacenamos nuevo recibo 
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO recibos(id_Recibo, numero, fecha, id_Empleado, monto, concepto, estado, id_Obra)" +
                " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", rep.IDRECIBO, rep.NUMERO,rep.FECHA, rep.IDEMPLEADO, rep.MONTO, rep.CONCEPTO, rep.ESTADO, rep.IDOBRA), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }
    }
}
