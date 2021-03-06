﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexiones;
using System.Data;
using MySql.Data.MySqlClient;

namespace Clases
{
    public class MovEquipo
    {
        private int idMeq;
        private String fecha;
        private int equipo;
        private int obra;
        private String tipo;
        private String detalle;
        private float numero;

        public int IDMEQ { get => idMeq; set => idMeq = value; }
        public string FECHA { get => fecha; set => fecha = value; }
        public int EQUIPO { get => equipo; set => equipo = value; }
        public int OBRA { get => obra; set => obra = value; }
        public string TIPO { get => tipo; set => tipo = value; }
        public string DETALLE { get => detalle; set => detalle = value; }
        public float NUMERO { get => numero; set => numero = value; }

        //==================  Métodos estáticos de la clase ===============================
        
        // estrae la totalidad de las novedades
        public static DataTable todoMovEq()
        {
            String cmd = "SELECT id_MovEq, fecha, id_Equipo, id_Obra, tipo, detalle, numero FROM movequipos";
            // 
            DataSet ds = Accesos.datos(cmd); //accesos  es la clase de lectura de datos
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }
        // Extrae novedades por EQUIPO y por TIPO de novedades ============================================
        public static DataTable paraBusqueda(int eqpo, string to)
        {
            String cmd = "SELECT  fecha, detalle, numero FROM movequipos "+
                "WHERE id_Equipo= " + eqpo + " AND tipo ='"+ to +"'";
            // 
            DataSet ds = Accesos.datos(cmd); //accesos  es la clase de lectura de datos
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        // Extrae todas las novedades por EQUIPO =======================================================
        public static DataTable buscarPorEquipo(int eqpo)
        {
            String cmd = "SELECT  id_MovEq, fecha, tipo, detalle, numero FROM movequipos " +
                "WHERE id_Equipo= " + eqpo;
            // 
            DataSet ds = Accesos.datos(cmd); 
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        // Almacena los datos del movimiento     =======================================================
        public static int guardaMovEquipo(MovEquipo rep)
        {
            // almacenamos nuevo parte diario. Incluso el idParte tiene valor 0
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO movequipos(id_MovEq, fecha, id_Equipo, id_Obra, tipo, detalle, numero)" +
                " VALUES ({0},'{1}',{2},{3},'{4}','{5}','{6}')", rep.IDMEQ, rep.FECHA, rep.EQUIPO, rep.OBRA, rep.TIPO, rep.DETALLE, rep.NUMERO), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }

        // Almacena los datos del movimiento     =======================================================
        public static int modifMovEquipo(MovEquipo rep, int orden)
        {
            // almacenamos la modificación del movimiento de equipo. 
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("UPDATE movequipos SET id_MovEq='{0}', detalle='{1}', numero='{2}' where id_MovEq='{3}'", rep.IDMEQ, rep.DETALLE, rep.NUMERO, orden), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }
    }
}
