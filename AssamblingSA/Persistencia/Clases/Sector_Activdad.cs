using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Clases;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia.Clases
{
    public class Sector_Activdad : Persistencia
    {
        public static Common.Clases.Sector_Actividad TraerEspecifica_SA (Common.Clases.Sector_Actividad pSA)
        {
            Common.Clases.Sector_Actividad retorno = null;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("TraerEspecifico_SA", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codigoSA", pSA.Cod_SA));

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        retorno = new Common.Clases.Sector_Actividad();
                        retorno.Cod_SA = oReader["codigo"].ToString();
                        retorno.Sector = oReader["sector"].ToString();
                        retorno.Actividad = oReader["actividad"].ToString();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        
        }

        public static List<Common.Clases.Sector_Actividad> TraerTodos()
        {
            List<Common.Clases.Sector_Actividad> retorno = new List<Common.Clases.Sector_Actividad>();
            Common.Clases.Sector_Actividad sa;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion); //pasaba la cadena de conexion el string
                conn.Open();

                // 1. identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("TraerTodosSA", conn);

                // 2. identificamos el tipo de ejecución, en este caso un SP
                cmd.CommandType = CommandType.StoredProcedure;

                // ejecutamos el store desde c# leyendo con el Reader
                using (SqlDataReader oReader = cmd.ExecuteReader())
                {

                    while (oReader.Read())
                    {
                        sa = new Common.Clases.Sector_Actividad();
                        sa.Cod_SA = oReader["codigo"].ToString();
                        sa.Sector = oReader["sector"].ToString();
                        sa.Actividad = oReader["actividad"].ToString();
                        retorno.Add(sa);
                    }

                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }
    }
}
