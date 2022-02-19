using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaConexión
{
    class Conn
    {
        public static string ConexionOracle(int op)
        {
            //Resultado de la selección
            string conexion;

            //Opción 1 para usar el TNSNAME
            //Cualquier otro número sera sin TNSNAME
            return conexion = op == 1
                ? "Data Source = UNAH; User ID = G5_19; Password = op7wDCVP;"
                : "Data Source = (DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 52.152.236.67)" +  //OP != 1
                  "(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SID = xe)));" +
                  " User Id = G5_19; Password = op7wDCVP;";
        }
    }
}
