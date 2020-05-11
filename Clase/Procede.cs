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
    public class Procede
    {
        private int idProv;
        private String nombre;
        private String direccion;
        private String cuit;

        public int IDPROV { get => idProv; set => idProv = value; }
        public string NOMBRE { get => nombre; set => nombre = value; }
        public string DIRECCION { get => direccion; set => direccion = value; }
        public string CUIT { get => cuit; set => cuit = value; }

        //================== Metodos estaticos de la clase ======================
        public static DataTable extraeProcedencia()
        {
            String cmd = "SELECT id_Prov, nombre FROM proveedor";
            // 
            DataSet ds = Accesos.datos(cmd);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }
        public static DataTable extraeTodoProv()
        {
            String cmd = "SELECT id_Prov, nombre,direccion,cuit FROM proveedor";
            // 
            DataSet ds = Accesos.datos(cmd);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }
        public static int guardaProced(Procede rep)
        {
            // almacenamos nuevo proveedor. 
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO proveedor(id_Prov, nombre,direccion,cuit)" +
                " VALUES ({0},'{1}','{2}','{3}')", rep.IDPROV, rep.NOMBRE,rep.DIRECCION, rep.CUIT), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }
        public static int modificaEstado(Procede rep, int orden)
        {
            // aca solamente modificamos los datos del proveedor
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("UPDATE proveedor SET id_Prov='{0}',nombre='{1}',direccion='{2}',cuit='{3}' WHERE id_Prov='{4}'",
                +rep.IDPROV, rep.NOMBRE, rep.DIRECCION, rep.CUIT, orden), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }
    }
}
