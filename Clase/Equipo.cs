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
    public class Equipo
    {
        private int idEquipo;
        private String tipo;
        private String alias;
        private String marca;
        private String modelo;
        private String estado;

        public int IDEQUIPO { get => idEquipo; set => idEquipo = value; }
        public string TIPO { get => tipo; set => tipo = value; }
        public string ALIAS { get => alias; set => alias = value; }
        public string MARCA { get => marca; set => marca = value; }
        public string MODELO { get => modelo; set => modelo = value; }
        public string ESTADO { get => estado; set => estado = value; }

        //==================  Métodos estáticos de la clase ===============================

        public static DataTable todoEquipo()
        {
            String cmd = "SELECT id_Equipo, tipo, alias, marca," +
                "modelo,estado FROM equipos";
            // 
            DataSet ds = Accesos.datos(cmd); //accesos  es la clase de lectura de datos
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        public static DataTable partEquipo()
        {
            String cmd = "SELECT id_Equipo, alias FROM equipos";
            // 
            DataSet ds = Accesos.datos(cmd); //accesos  es la clase de lectura de datos
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        public static int guardaEquipo(Equipo rep)
        {
            // almacenamos nuevo parte diario. Incluso el idParte tiene valor 0
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO equipos(id_Equipo, tipo, alias, marca,modelo,estado)" +
                " VALUES ({0},'{1}',{2},{3},'{4}','{5}')", rep.IDEQUIPO, rep.TIPO, rep.ALIAS, rep.MARCA, rep.MODELO, rep.ESTADO), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }

        public static int modificaEquipo(Equipo rep, int orden)
        {
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("UPDATE equipos SET id_Equipo='{0}',tipo='{1}',alias='{2}',marca='{3}',modelo='{4}',estado='{5}' WHERE id_Equipo='{6}'",
                +rep.IDEQUIPO, rep.TIPO, rep.ALIAS, rep.MARCA,rep.MODELO,rep.ESTADO, orden), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }
    }
}
