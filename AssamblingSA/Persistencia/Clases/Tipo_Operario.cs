using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Clases;
using System.Data.SqlClient;
using System.Data;
namespace Persistencia.Clases
{
    public class Tipo_Operario : Persistencia
    {
        public static bool Agregar(Common.Clases.Tipo_Operario pTipoOperario)
        {
            bool retorno = true;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                // 1. identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("Tipo_Operario_Agregar", conn);

                // 2. identificamos el tipo de ejecución, en este caso un SP
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. en caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@nom", pTipoOperario.Nom_TO));
                cmd.Parameters.Add(new SqlParameter("@valor_hora", pTipoOperario.Valor_hora_TO));

                // ejecutamos el store desde c#
                int rtn = cmd.ExecuteNonQuery();

                if (rtn <= 0)
                {
                    retorno = false;
                }

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        public static bool Eliminar(Common.Clases.Tipo_Operario pTipoOperario)
        {
            bool retorno = true;
            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Tipo_Operario_Eliminar", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nom", pTipoOperario.Nom_TO));
                int rtn = cmd.ExecuteNonQuery();
                if(rtn <= 0)
                {
                    retorno = false;
                }
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return retorno;
        }

        public static bool Modificar(Common.Clases.Tipo_Operario pTipoOperario)
        {
            bool retorno = true;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                //1. identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("Tipo_Operario_Modificar", conn);

                //2. identificamos el tipo de ejecucion, en este caso un sp
                cmd.CommandType = CommandType.StoredProcedure;

                //3- en caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@Nombre", pTipoOperario.Nom_TO));
                cmd.Parameters.Add(new SqlParameter("@valor_hora", pTipoOperario.Valor_hora_TO));
                //ejecutamos el store desde c#
                int rtn = cmd.ExecuteNonQuery();

                if (rtn <= 0)
                {
                    retorno = false;
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }

        public static List<Common.Clases.Tipo_Operario> TraerTodos()
        {
            List<Common.Clases.Tipo_Operario> retorno = new List<Common.Clases.Tipo_Operario>();
            Common.Clases.Tipo_Operario tipop;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                SqlCommand cmd = new SqlCommand("TraerTodosTipo_Operario", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        tipop = new Common.Clases.Tipo_Operario();
                        tipop.Nom_TO = oReader["nom"].ToString();
                        tipop.Valor_hora_TO = int.Parse(oReader["valor_hora"].ToString());
                        retorno.Add(tipop);
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

        public static Common.Clases.Tipo_Operario TraerEspecifica(Common.Clases.Tipo_Operario pTipo)
        {
            Common.Clases.Tipo_Operario retorno = null;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                //1. Identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("TraerEspecifico_TipoOperario", conn);

                //2. Identificamos el tipo de ejecucion, en este caso un SP
                cmd.CommandType = CommandType.StoredProcedure;

                //3. En caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@Nom_Op", pTipo.Nom_TO));

                // Ejecutamos el store desde c#
                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        retorno = new Common.Clases.Tipo_Operario();
                        retorno.Nom_TO = oReader["nom"].ToString();
                        retorno.Valor_hora_TO = int.Parse(oReader["valor_hora"].ToString());
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
