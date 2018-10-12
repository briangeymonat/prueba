using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Clases;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia.Clases
{
    public class Cliente : Persistencia
    {
        public static bool Agregar(Common.Clases.Cliente pCliente)
        {
            bool retorno = true;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                //1. identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("Cliente_Agregar", conn);

                //2. identificamos el tipo de ejecución, en este caso un Stored Procedure;
                cmd.CommandType = CommandType.StoredProcedure;

                //3. en caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@Nombre", pCliente.Nombre));

                cmd.Parameters.Add(new SqlParameter("@Direccion", pCliente.Direccion));

                cmd.Parameters.Add(new SqlParameter("@Identificador", pCliente.Cat.Identificador));

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

        public static List<Common.Clases.Cliente> TraerTodas()
        {
            List<Common.Clases.Cliente> retorno = new List<Common.Clases.Cliente>();
            Common.Clases.Cliente cli;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                SqlCommand cmd = new SqlCommand("Cliente_TraerTodas", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        cli = new Common.Clases.Cliente();
                        cli.idCliente = int.Parse(oReader["idCliente"].ToString());
                        cli.Nombre = oReader["Nombre"].ToString();
                        cli.Direccion = oReader["Direccion"].ToString();
                        cli.Cat.Identificador = int.Parse(oReader["Identificador"].ToString());
                        cli.Cat = new Common.Clases.Categoria();
                        
                        cli.Cat = Categoria.TraerEspecifica(cli.Cat);

                        retorno.Add(cli);
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

        public static bool Eliminar(Common.Clases.Cliente pCliente)
        {
            bool retorno = true;
            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                // 1. identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("Cliente_Eliminar", conn);

                // 2. identificamos el tipo de ejecución, en este caso un SP
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. en caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@idCliente", pCliente.idCliente));

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

        public static Common.Clases.Cliente TraerEspecifica(Common.Clases.Cliente pCliente)
        {
            Common.Clases.Cliente retorno = null;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                //1. Identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("Cliente_TraerEspecifica", conn);

                //2. Identificamos el tipo de ejecucion, en este caso un SP
                cmd.CommandType = CommandType.StoredProcedure;

                //3. En caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@idCliente", pCliente.idCliente));

                // Ejecutamos el store desde c#
                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        retorno = new Common.Clases.Cliente();
                        retorno.idCliente = int.Parse(oReader["idCliente"].ToString());
                        retorno.Nombre = oReader["Nombre"].ToString();
                        retorno.Direccion = oReader["Direccion"].ToString();
                        retorno.Cat = new Common.Clases.Categoria();
                        retorno.Cat.Identificador = int.Parse(oReader["Identificador"].ToString());
                        retorno.Cat = Categoria.TraerEspecifica(retorno.Cat);
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

        public static bool Modificar(Common.Clases.Cliente pCliente)
        {
            bool retorno = true;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                //1. identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("Cliente_Modificar", conn);

                //2. identificamos el tipo de ejecucion, en este caso un sp
                cmd.CommandType = CommandType.StoredProcedure;

                //3- en caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@idCliente", pCliente.idCliente));
                cmd.Parameters.Add(new SqlParameter("@Nombre", pCliente.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Direccion", pCliente.Direccion));
                cmd.Parameters.Add(new SqlParameter("@Identificador", pCliente.Cat.Identificador)); //no se si hay que instanciar la categoria y como traer a la  categoria competa

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
