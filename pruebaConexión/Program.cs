using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;

namespace pruebaConexión
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                OracleConnection objConexion = new OracleConnection(Conn.ConexionOracle(2));
                string UsuarioId = "U1";
                objConexion.Open(); //abriendo conexión Oracle
                OracleCommand objComando = new OracleCommand();
                objComando.Connection = objConexion;
                objComando.CommandText = "G5_19.SEGURIDAD.p_INGRESO_USUARIO";   //Comando a ejecutar
                objComando.CommandType = CommandType.StoredProcedure;           //Indicar que es un procedimiento almacenado
                OracleParameter[] parm = new OracleParameter[2];
                //Parametros
                parm[0] = objComando.Parameters.Add("p_usuario", OracleDbType.Varchar2, UsuarioId, ParameterDirection.Input);
                objComando.Parameters.Add("resultado", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                objComando.ExecuteNonQuery();
                //Llenado del DataSet
                OracleDataAdapter dataAdapter = new OracleDataAdapter(objComando);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "ID_USUARIO");

                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    var algo = dataSet.Tables[0];
                    Console.WriteLine(algo.Rows[0]["NOMBRES"].ToString());
                    Console.WriteLine(algo.Rows[0]["ID_USUARIO"].ToString());   //Retorna una tabla
                    Console.WriteLine(algo.Rows[0]["USR_CLAVE"].ToString());
                    
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("nadita");    //Si no hay coincidencia, no retorna nada
                }
            }
            catch (OracleException ex)
            {
                throw ex;
            } //Cambiar parametro para no usar TNSNAME
        }
    }
}
