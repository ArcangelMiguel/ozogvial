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
    public class Material
    {
        private int idMat;
        private int idTipo;
        private String detalle;
        private String unidad;
        private float adquirido;
        private float recibido;
        private float proceso;
        private float stock;
        private float referencia;
        private String anotacion;

        public int IDMAT { get => idMat; set => idMat = value; }
        public int IDTIPO { get => idTipo; set => idTipo = value; }
        public String DETALLE { get => detalle; set => detalle = value; }
        public String UNIDAD { get => unidad; set => unidad = value; }
        public float ADQUIRIDO { get => adquirido; set => adquirido = value; }
        public float RECIBIDO { get => recibido; set => recibido = value; }
        public float PROCESO { get => proceso; set => proceso = value; }
        public float STOCK { get => stock; set => stock = value; }
        public float REFERENCIA { get => referencia; set => referencia = value; }
        public String ANOTA { get => anotacion; set => anotacion = value; }

        //==================  Métodos estáticos de la clase ===============================
        public static DataTable extraeTodos()
        {
            // ESTRAEMOS TODOS LOS DATOS DE LOS MATERIALES E INSUMOS
            String cmd = "SELECT MAT.id_Mat, TIP.detalle, MAT.detalle, MAT.unidad, MAT.adquirido, MAT.recibido, MAT.proceso," +
                "MAT.stock, MAT.referencia, MAT.anotacion FROM material AS MAT " +
                "INNER JOIN tipos AS TIP on MAT.id_Tipo = TIP.id_Tipo";
            DataSet ds = Accesos.datos(cmd); //accesos  es la clase de lectura de datos
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }
        public static DataTable extraeParaInventario(int idmat)
        {
            //  Estraemos solo algunos datos como referencia cuando
            //  vamos a hacer movimiento de inventario
            String cmd = "SELECT  id_Mat, detalle, unidad, stock FROM material " +
                "WHERE id_Mat= " + idmat+"'";            
            DataSet ds = Accesos.datos(cmd); //accesos  es la clase de lectura de datos
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        public static int guardaMaterial(Material rep)
        {
            // almacenamos materiales
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO material(id_Mat,id_Tipo,detalle,unidad,adquirido,recibido,proceso,stock,referencia,anotacion)" +
                " VALUES ({0},{1},'{2}','{3}',{4},{5},{6},{7},{8},'{9}')", rep.IDMAT, rep.IDTIPO, rep.DETALLE, rep.UNIDAD, rep.ADQUIRIDO, rep.RECIBIDO, rep.PROCESO, rep.STOCK, rep.REFERENCIA, rep.ANOTA), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }

        public static int modificaCantidades(Material rep, int orden)
        {
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("UPDATE Material SET id_Mat='{0}',adquirido='{1}',recibido='{2}',proceso='{3}',stock='{4}'"+
                "WHERE id_Equipo='{5}'", rep.IDMAT, rep.ADQUIRIDO, rep.RECIBIDO, rep.PROCESO, rep.STOCK, orden), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }


    }
}
