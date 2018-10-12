using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Clases;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia.Clases
{
    public class Pieza : Persistencia
    {
        public static bool Agregar(Common.Clases.Pieza pPieza)
        {
            bool retorno = true;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                //1. identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("Pieza_Agregar", conn);

                //2. identificamos el tipo de ejecución, en este caso un Stored Procedure;
                cmd.CommandType = CommandType.StoredProcedure;

                //3. en caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@codigo", pPieza.Cod_pieza));
                cmd.Parameters.Add(new SqlParameter("@nom", pPieza.Nom_pieza));
                cmd.Parameters.Add(new SqlParameter("@valor", pPieza.Valor_pieza));
                cmd.Parameters.Add(new SqlParameter("@codigoSA", pPieza.SA.Cod_SA));
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
        
        public static bool Eliminar(Common.Clases.Pieza pPieza)
        {
            bool retorno = true;
            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                // 1. identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("Pieza_Eliminar", conn);

                // 2. identificamos el tipo de ejecución, en este caso un SP
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. en caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@codigo", pPieza.Cod_pieza));

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

        public static bool Modificar(Common.Clases.Pieza pPieza)
        {
            bool retorno = true;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                //1. identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("Pieza_Modificar", conn);

                //2. identificamos el tipo de ejecucion, en este caso un sp
                cmd.CommandType = CommandType.StoredProcedure;

                //3- en caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@Codigo", pPieza.Cod_pieza));
                cmd.Parameters.Add(new SqlParameter("@Nombre", pPieza.Nom_pieza ));
                cmd.Parameters.Add(new SqlParameter("@Valor", pPieza.Valor_pieza));
                cmd.Parameters.Add(new SqlParameter("@codigoSA", pPieza.SA.Cod_SA));
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

        public static List<Common.Clases.Pieza> TraerTodasPieza()
        {
            List<Common.Clases.Pieza> retorno = new List<Common.Clases.Pieza>();
            Common.Clases.Pieza pieza;
            Common.Clases.Sector_Actividad sec;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                SqlCommand cmd = new SqlCommand("TraerTodosPiezas", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        pieza = new Common.Clases.Pieza();
                        pieza.Cod_pieza = int.Parse(oReader["codigo"].ToString());
                        pieza.Nom_pieza = oReader["nom"].ToString();
                        pieza.Valor_pieza = int.Parse(oReader["valor"].ToString());
                        sec = new Common.Clases.Sector_Actividad();
                        sec.Cod_SA = oReader["codigoSA"].ToString();
                        pieza.SA =  Sector_Activdad.TraerEspecifica_SA(sec);

                        retorno.Add(pieza);
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

        public static Common.Clases.Pieza TraerEspecifica(Common.Clases.Pieza pPieza)
        {
            Common.Clases.Pieza retorno = null;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                //1. Identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("TraerEspecifico_Pieza", conn);

                //2. Identificamos el tipo de ejecucion, en este caso un SP
                cmd.CommandType = CommandType.StoredProcedure;

                //3. En caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@Cod_Pieza", pPieza.Cod_pieza));

                // Ejecutamos el store desde c#
                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        retorno = new Common.Clases.Pieza();
                        retorno.Cod_pieza = int.Parse(oReader["codigo"].ToString());
                        retorno.Nom_pieza = oReader["nom"].ToString();
                        retorno.Valor_pieza = int.Parse(oReader["valor"].ToString());
                        Common.Clases.Sector_Actividad s = new Common.Clases.Sector_Actividad(); 
                        s.Cod_SA = oReader["codigoSA"].ToString();
                        retorno.SA = s;
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

        public static bool ExistePiezaAutomovil(Common.Clases.Automovil pA, Common.Clases.Pieza pP)
        {
            bool retorno = false;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();
                
                SqlCommand cmd = new SqlCommand("TraerEspecifico_PiezaAutomovil", conn);
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id_A", pA.Id));
                cmd.Parameters.Add(new SqlParameter("@codigo_P", pP.Cod_pieza));

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    if(oReader.Read())
                    {
                        retorno = true;
                    }
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return retorno;
        }
    }
}
