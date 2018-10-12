using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Clases;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia.Clases
{
    public class Operario : Persistencia
    {
        public static bool Agregar(Common.Clases.Operario pOperario)
        {
            bool retorno = true;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                //1. identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("Operario_Agregar", conn);

                //2. identificamos el tipo de ejecución, en este caso un Stored Procedure;
                cmd.CommandType = CommandType.StoredProcedure;

                //3. en caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@ci", pOperario.Ci));
                cmd.Parameters.Add(new SqlParameter("@nom", pOperario.Nombre));
                cmd.Parameters.Add(new SqlParameter("@dir", pOperario.Direccion));
                cmd.Parameters.Add(new SqlParameter("@tel", pOperario.Telefono));
                cmd.Parameters.Add(new SqlParameter("@tipo", pOperario.Tipo_op.Nom_TO));
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

        public static List<Common.Clases.Operario> TraerTodas()
        {
            List<Common.Clases.Operario> retorno = new List<Common.Clases.Operario>();
            Common.Clases.Operario ope;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                SqlCommand cmd = new SqlCommand("TraerTodosOperarios", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader oReader = cmd.ExecuteReader()) // en un SELECT es SqlDataReader
                {
                    while (oReader.Read())
                    {
                        ope = new Common.Clases.Operario();
                        ope.Ci = oReader["ci"].ToString();
                        ope.Nombre = oReader["nom"].ToString();
                        ope.Direccion = oReader["dir"].ToString();
                        ope.Telefono = oReader["tel"].ToString();
                        Common.Clases.Tipo_Operario to = new Common.Clases.Tipo_Operario();
                        to.Nom_TO = oReader["tipo"].ToString();
                        ope.Tipo_op = to;
                        retorno.Add(ope);
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

        public static bool Eliminar(Common.Clases.Operario pOperario)
        {
            bool retorno = true;
            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                // 1. identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("Operario_Eliminar", conn);

                // 2. identificamos el tipo de ejecución, en este caso un SP
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. en caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@ci", pOperario.Ci));

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

        public static Common.Clases.Operario TraerEspecifica(Common.Clases.Operario pOperario)
        {
            Common.Clases.Operario retorno = null;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                //1. Identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("TraerEspecifico_Operarios", conn);

                //2. Identificamos el tipo de ejecucion, en este caso un SP
                cmd.CommandType = CommandType.StoredProcedure;

                //3. En caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@ci", pOperario.Ci));

                // Ejecutamos el store desde c#
                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        retorno = new Common.Clases.Operario();
                        retorno.Ci = oReader["ci"].ToString();
                        retorno.Nombre = oReader["nom"].ToString();
                        retorno.Direccion = oReader["dir"].ToString();
                        retorno.Telefono = oReader["tel"].ToString();
                        Common.Clases.Tipo_Operario to = new Common.Clases.Tipo_Operario();
                        to.Nom_TO = oReader["tipo"].ToString();
                        to.Valor_hora_TO = int.Parse(oReader["valor_hora"].ToString());
                        retorno.Tipo_op = to;
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

        public static bool Modificar(Common.Clases.Operario pOperario)
        {
            bool retorno = true;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                //1. identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("Operario_Modificar", conn);

                //2. identificamos el tipo de ejecucion, en este caso un sp
                cmd.CommandType = CommandType.StoredProcedure;

                //3- en caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@ci", pOperario.Ci));
                cmd.Parameters.Add(new SqlParameter("@nom", pOperario.Nombre));
                cmd.Parameters.Add(new SqlParameter("@dir", pOperario.Direccion));
                cmd.Parameters.Add(new SqlParameter("@tel", pOperario.Telefono));
                cmd.Parameters.Add(new SqlParameter("@tipo", pOperario.Tipo_op.Nom_TO));
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
       

      

    }
}
