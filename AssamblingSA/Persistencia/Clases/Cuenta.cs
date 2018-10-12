using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Clases;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia.Clases
{
    public class Cuenta : Persistencia
    {
        public static Common.Clases.Cuenta Verificar(Common.Clases.Cuenta pCuenta)
        {
            Common.Clases.Cuenta retorno = null;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                SqlCommand cmd = new SqlCommand("IniciarSesion", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Usuario", pCuenta.Usuario));
                cmd.Parameters.Add(new SqlParameter("@Contraseña", pCuenta.Contraseña));

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while(oReader.Read())
                    {
                        retorno = new Common.Clases.Cuenta();
                        retorno.Usuario = oReader["Usuario"].ToString();
                        retorno.Contraseña = oReader["Contraseña"].ToString();
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
