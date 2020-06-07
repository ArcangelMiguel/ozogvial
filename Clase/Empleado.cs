using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexiones;
using System.Data;
using MySql.Data.MySqlClient;

namespace Clase
{
    class Empleado
    {
        private int idEmpleado;
        private String apellido;
        private String nombre;
        private String documento;
        private String cuil;
        private String direccion;
        private String postal;
        private String ciudad;
        private String provincia;
        private String alta;
        private String baja;
        private String nacimiento;
        private String telefono;
        private String correo;
        private String clave;
        private int categoria;
        private String camisa;
        private String pantalon;
        private String zapato;
        private int estado; 
        private String anota;

        public int IDEMPLEADO { get => idEmpleado; set => idEmpleado = value; }
        public String APELLIDO { get => apellido; set => apellido = value; }
        public String NOMBRE { get => nombre; set => nombre = value; }
        public String DOCUMENTO { get => documento; set => documento = value; }
        public String CUIL { get => cuil; set => cuil = value; }
        public String DIRECCION { get => direccion; set => direccion = value; }
        public String POSTAL { get => postal; set => postal = value; }
        public String CIUDAD { get => ciudad; set => ciudad = value; }
        public String PROVINCIA { get => provincia; set => provincia = value; }
        public String ALTA { get => alta; set => alta = value; }
        public String BAJA { get => baja; set => baja = value; }
        public String NACIMIENTO { get => nacimiento; set => nacimiento = value; }
        public String TELEFONO { get => telefono; set => telefono = value; }
        public String CORREO { get => correo; set => correo = value; }
        public String CLAVE { get => clave; set => clave = value; }
        public int CATEGORIA { get => categoria; set => categoria = value; }
        public String CAMISA { get => camisa; set => camisa = value; }
        public String PANTALON { get => pantalon; set => pantalon = value; }
        public String ZAPATO { get => zapato; set => zapato = value; }
        public int ESTADO { get => estado; set => estado = value; }
        public String ANOTA { get => anota; set => anota = value; }


        //==================  Métodos estáticos de la clase ===============================

        public static int guardaEmpleado(Empleado rep)
        {
            // almacenamos materiales
            int valor = 0;
            MySqlConnection connn = new MySqlConnection();
            connn = Accesos.UnaConexion();
            MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO empleado(id_Empleado,apellido,nombre,documento,cuil,direccion,postal,ciudad,provincia,"+
                                     "alta, baja, nacimiento, telefono, correo, clave, id_Categoria, camisa, pantalon, zapato, id_Estado, anotaciones)" +
                                     " VALUES ({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{9}','{10}','{11}','{12}','{13}','{14}'"+
                                     ",{15},'{16}','{17}','{18}',{19},'{20}'"+
                                     ")", rep.IDEMPLEADO, rep.APELLIDO, rep.NOMBRE, rep.DOCUMENTO, rep.CUIL, rep.DIRECCION, rep.POSTAL, rep.CIUDAD, rep.PROVINCIA,
                                     rep.ALTA, rep.BAJA, rep.NACIMIENTO, rep.TELEFONO, rep.CORREO, rep.CLAVE, rep.CATEGORIA, rep.CAMISA, rep.PANTALON, rep.ZAPATO,
                                     rep.ESTADO, rep.ANOTA), connn);

            valor = cmd.ExecuteNonQuery();
            connn.Close();
            return valor;
        }

    }
}
