using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Clases;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia.Clases
{
    public class Automovil : Persistencia
    {
        public static bool Agregar(Common.Clases.Automovil pAutomovil) 
        {
            bool retorno = true;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                // 1. identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("Automovil_Agregar", conn);

                // 2. identificamos el tipo de ejecución, en este caso un SP
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. en caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@modelo", pAutomovil.Modelo));

                // ejecutamos el store desde c#
                int rtn = cmd.ExecuteNonQuery();

                if (rtn <= 0)
                {
                    retorno = false;
                }

                if(conn.State== ConnectionState.Open)
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
        public static List<Common.Clases.Automovil> TraerTodas()
        {
            List<Common.Clases.Automovil> retorno = new List<Common.Clases.Automovil>();
            Common.Clases.Automovil auto;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion); //pasaba la cadena de conexion el string
                conn.Open();

                // 1. identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("TraerTodosAutomovil", conn); 

                // 2. identificamos el tipo de ejecución, en este caso un SP
                cmd.CommandType = CommandType.StoredProcedure;

                // ejecutamos el store desde c# leyendo con el Reader
                using (SqlDataReader oReader = cmd.ExecuteReader())
                {

                    while (oReader.Read())
                    {
                        auto = new Common.Clases.Automovil();
                        auto.Id = int.Parse(oReader["Id"].ToString());
                        auto.Modelo = oReader["modelo"].ToString();
                        retorno.Add(auto);
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
        public static bool Eliminar(Common.Clases.Automovil pAutomovil)
        {
            bool retorno = true;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                // 1. identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("Automovil_Eliminar", conn);

                // 2. identificamos el tipo de ejecución, en este caso un SP
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. en caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@Id", pAutomovil.Id));

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
        public static bool Modificar(Common.Clases.Automovil pAutomovil)
        {
            bool retorno = true;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                // 1. identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("Automovil_Modificar", conn);

                // 2. identificamos el tipo de ejecución, en este caso un SP
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. en caso de que los lleve se ponen los parametros del SP
                cmd.Parameters.Add(new SqlParameter("@Id", pAutomovil.Id));
                cmd.Parameters.Add(new SqlParameter("@modelo", pAutomovil.Modelo));

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
        public static Common.Clases.Automovil TraerEspecifica(Common.Clases.Automovil pAutomovil)
                {
                    Common.Clases.Automovil retorno = null;

                    try
                    {
                        var conn = new SqlConnection(CadenaDeConexion);
                        conn.Open();

                        // 1. identificamos el store procedure a ejecutar
                        SqlCommand cmd = new SqlCommand("TraerEspecifico_Automovil", conn);

                        // 2. identificamos el tipo de ejecución, en este caso un SP
                        cmd.CommandType = CommandType.StoredProcedure;

                        // 3. en caso de que los lleve se ponen los parametros del SP
                        cmd.Parameters.Add(new SqlParameter("@Id_A", pAutomovil.Id));

                        // ejecutamos el store desde c#
                        using (SqlDataReader oReader = cmd.ExecuteReader())
                        {

                            while (oReader.Read())
                            {
                                retorno = new Common.Clases.Automovil();
                                retorno.Id = int.Parse(oReader["Id"].ToString());
                                retorno.Modelo = oReader["modelo"].ToString();

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

        #region FABRICACION AUTOMOVIL
        public static bool AgregarPiezaAutomovil(Common.Clases.Automovil pAuto)
        {
            bool retorno = true;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("PiezaAutomovil_Agregar", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codigo_P", pAuto.PiezasAuto[0].Pieza.Cod_pieza));
                cmd.Parameters.Add(new SqlParameter("@Id_A", pAuto.Id));
                cmd.Parameters.Add(new SqlParameter("@cant", pAuto.PiezasAuto[0].Cantidad));

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

        public static bool EliminarPiezaAutomovil(Common.Clases.Automovil pAuto)
        {
            bool retorno = true;
            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("PiezaAutomovil_Eliminar", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id_A", pAuto.Id));
                cmd.Parameters.Add(new SqlParameter("@codigo_P", pAuto.PiezasAuto[0].Pieza.Cod_pieza));

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
        public static List<Common.Clases.Pieza_Automovil> TraerPiezasXAutomovil(Common.Clases.Automovil pAutomovil)
        {
            List<Common.Clases.Pieza_Automovil> lstPiezas = new List<Common.Clases.Pieza_Automovil>();
            Common.Clases.Sector_Actividad s;
            Common.Clases.Pieza piezaSola;
            Common.Clases.Pieza_Automovil pa;
            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                SqlCommand cmd = new SqlCommand("Listar_PiezasXAutomovil", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Id_A", pAutomovil.Id));

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {


                        pa = new Common.Clases.Pieza_Automovil();
                        
                        piezaSola = new Common.Clases.Pieza();
                        piezaSola.Cod_pieza = int.Parse(oReader["codigo_P"].ToString());
                        piezaSola.Nom_pieza = oReader["nom"].ToString();
                        piezaSola.Valor_pieza = int.Parse(oReader["valor"].ToString());
                        s = new Common.Clases.Sector_Actividad();
                        s.Cod_SA = oReader["codigoSA"].ToString();
                        piezaSola.SA = Sector_Activdad.TraerEspecifica_SA(s);

                        pa.Pieza = piezaSola;
                        pa.Cantidad = int.Parse(oReader["cant"].ToString());

                        lstPiezas.Add(pa);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPiezas;
        }

        public static int CostoXAutomovilPieza(Common.Clases.Automovil pAutomovil)
        {
            int costo = 0;
            string x = "";
            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();
               
                SqlCommand cmd = new SqlCommand("CostoXAutomovilPieza", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Id_A", pAutomovil.Id));


                using (SqlDataReader oReader = cmd.ExecuteReader())
                {

                    while (oReader.Read())
                    {
                        x = oReader["COSTO_P"].ToString();
                        if (x != "")
                            costo = int.Parse(oReader["COSTO_P"].ToString());
                        else
                            costo = 0;

                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return costo;
        }


        public static int CostoXAutomovilOperario (Common.Clases.Automovil pAutomovil)
        {
            int costo = 0 ;
            string x = "";
            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("CostoXAutomovilOperario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id_A", pAutomovil.Id));
                using (SqlDataReader oReader = cmd.ExecuteReader())
                {

                    while (oReader.Read())
                    {
                        x = oReader["COSTO_OP"].ToString();
                        if (x != "")
                            costo = int.Parse(oReader["COSTO_OP"].ToString());
                        else costo = 0;

                    }

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return costo;
        }

        public static int HorasXAutomovil(Common.Clases.Automovil pAutomovil)
        {
            int horas = new int();
            string x = "";
            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Listar_HorasXAutomovil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id_A", pAutomovil.Id));

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {

                    while (oReader.Read())
                    {
                        x = oReader["HORAS"].ToString();
                        if (x != "")
                            horas = int.Parse(oReader["HORAS"].ToString());
                        else
                            horas = 0;
                    }
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
            return horas;
        }

        public static int CantOpXAutomovil(Common.Clases.Automovil pAutomovil)
        {
            int ope = 0;
            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Listar_CantOperariosXAutomovil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id_A", pAutomovil.Id));

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {

                    while (oReader.Read())
                    {

                        ope = int.Parse(oReader["OPERARIO"].ToString());

                    }
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
            return ope;
        }

        public static List<Common.Clases.CantTipoXAutomovil> CantTipoXAutomovil(Common.Clases.Automovil pAutomovil)
        {
            List<Common.Clases.CantTipoXAutomovil> retorno = new List<Common.Clases.CantTipoXAutomovil>();
            Common.Clases.CantTipoXAutomovil cantTipo;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                // 1. identificamos el store procedure a ejecutar
                SqlCommand cmd = new SqlCommand("Listar_CantTipoOperariosXAutomovil", conn);

                cmd.Parameters.Add(new SqlParameter("@Id_A", pAutomovil.Id));

                // 2. identificamos el tipo de ejecución, en este caso un SP
                cmd.CommandType = CommandType.StoredProcedure;

                // ejecutamos el store desde c#
                using (SqlDataReader oReader = cmd.ExecuteReader())
                {

                    while (oReader.Read())
                    {
                        cantTipo = new Common.Clases.CantTipoXAutomovil();
                        cantTipo.Tipo = oReader["tipo"].ToString();
                        cantTipo.Cant = int.Parse(oReader["cant"].ToString());
                        retorno.Add(cantTipo);
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

        #endregion

        #region TABLA TRABAJA

        public static bool AgregarTrabaja(Common.Clases.Trabaja pTra)
        {
            bool retorno = true;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Trabaja_Agregar", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ci", pTra.Operario.Ci));
                cmd.Parameters.Add(new SqlParameter("@cod_Sec_Act", pTra.S_A.Cod_SA));
                cmd.Parameters.Add(new SqlParameter("@Id_A", pTra.Automovil.Id));
                cmd.Parameters.Add(new SqlParameter("@cant_Horas", pTra.Cant_horas));


                int rtn = cmd.ExecuteNonQuery();
                if (rtn <= 0)
                    retorno = false;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return retorno;
        }
        public static bool EliminarTrabaja(Common.Clases.Trabaja pTra)
        {
            bool retorno = true;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Trabaja_Eliminar", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ci", pTra.Operario.Ci));
                cmd.Parameters.Add(new SqlParameter("@cod_Sec_Act", pTra.S_A.Cod_SA));
                cmd.Parameters.Add(new SqlParameter("@Id_A", pTra.Automovil.Id));

                int rtn = cmd.ExecuteNonQuery();
                if (rtn <= 0)
                    retorno = false;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }
        public static bool ExisteTrabajo(Common.Clases.Operario op, Common.Clases.Sector_Actividad se, Common.Clases.Automovil auto)
        {
            bool retorno = false;

            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();

                SqlCommand cmd = new SqlCommand("TraerEspecifico_Trabaja", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ci", op.Ci));
                cmd.Parameters.Add(new SqlParameter("@codSecAct", se.Cod_SA));
                cmd.Parameters.Add(new SqlParameter("@Id_A", auto.Id));

                // ejecutamos el store desde c#
                using (SqlDataReader oReader = cmd.ExecuteReader())
                {

                    while (oReader.Read())
                    {
                        retorno = true;

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
        public static List<Common.Clases.Trabaja> TraerDatos(Common.Clases.Trabaja pTrabaja)
        {
            Common.Clases.Trabaja retorno = null;
            List<Common.Clases.Trabaja> lst = new List<Common.Clases.Trabaja>();
            try
            {
                var conn = new SqlConnection(CadenaDeConexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("TraerDatos_Trabaja", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id_A", pTrabaja.Automovil.Id));
                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while(oReader.Read())
                    {
                        retorno = new Common.Clases.Trabaja();
                        retorno.Operario = new Common.Clases.Operario();
                        retorno.Operario.Ci = oReader["ci"].ToString();
                        retorno.Operario.Nombre = oReader["nom"].ToString();
                        retorno.S_A = new Common.Clases.Sector_Actividad();
                        retorno.S_A.Cod_SA = oReader["cod_Sec_Act"].ToString();
                        retorno.Automovil =new Common.Clases.Automovil();
                        retorno.Automovil.Id = int.Parse(oReader["Id_A"].ToString());
                        retorno.Cant_horas = int.Parse(oReader["cant_Horas"].ToString());
                        lst.Add(retorno);

                    }
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return lst;
        }


    }

        #endregion

    }

