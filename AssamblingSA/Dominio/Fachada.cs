using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Fachada
    {
        #region Metodos de Automovil

        public static bool Automovil_Agregar(Common.Clases.Automovil pAutomovil)
        {
            return Dominio.Clases.Automovil.Agregar(pAutomovil);
        }

        public static List<Common.Clases.Automovil> Automovil_TraerTodas()
        {
            return Dominio.Clases.Automovil.TraerTodas();
        }

        public static bool Automovil_Eliminar(Common.Clases.Automovil pAutomovil)
        {
            return Dominio.Clases.Automovil.Eliminar(pAutomovil);
        }
        

        public static bool Automovil_Modificar(Common.Clases.Automovil pAutomovil)
        {
            return Dominio.Clases.Automovil.Modificar(pAutomovil);
        }
        public static Common.Clases.Automovil Automovil_TraerEspecifica(Common.Clases.Automovil pAutomovil)
        {
            return Dominio.Clases.Automovil.TraerEspecifica_Automovil(pAutomovil);
        }

        #endregion


        #region Metodos de Operario

        public static bool Operario_Agregar(Common.Clases.Operario pOperario)
        {
            return Dominio.Clases.Operario.Agregar(pOperario);
        }

        public static List<Common.Clases.Operario> Operario_TraerTodas()
        {
            return Dominio.Clases.Operario.TraerTodas();
        }

        public static bool Operario_Eliminar(Common.Clases.Operario pOperario)
        {
            return Dominio.Clases.Operario.Eliminar(pOperario);
        }

        public static Common.Clases.Operario Operario_TraerEspecifica(Common.Clases.Operario pOperario)
        {
            return Dominio.Clases.Operario.TraerEspecifica(pOperario);
        }

        public static bool Operario_Modificar(Common.Clases.Operario pOperario)
        {
            return Dominio.Clases.Operario.Modificar(pOperario);
        }
        #endregion
   

        #region Metodos de Pieza

        public static bool Pieza_Agregar(Common.Clases.Pieza pPieza)
        {
            return Dominio.Clases.Pieza.Agregar(pPieza);
        }

        public static List<Common.Clases.Pieza> Pieza_TraerTodas()
        {
            return Dominio.Clases.Pieza.TraerTodasPieza();
        }

        public static bool Pieza_Eliminar(Common.Clases.Pieza pPieza)
        {
            return Dominio.Clases.Pieza.Eliminar(pPieza);
        }
        public static bool Pieza_Modificar(Common.Clases.Pieza pPieza)
        {
            return Dominio.Clases.Pieza.Modificar(pPieza);
        }
        public static Common.Clases.Pieza Pieza_TraerEspecifica(Common.Clases.Pieza pPieza)
        {
            return Dominio.Clases.Pieza.TraerEspecifica(pPieza);
        }

        public static bool ExistePiezaAutomovil(Common.Clases.Automovil pA, Common.Clases.Pieza pP)
        {
            return Dominio.Clases.Pieza.ExistePiezaAutomovil(pA, pP);
        }

        #endregion

        #region Metodos de Tipo de Operario

        public static bool TipoOperario_Agregar(Common.Clases.Tipo_Operario pTipoOperario)
        {
            return Dominio.Clases.Tipo_Operario.Agregar(pTipoOperario);
        }

        public static List<Common.Clases.Tipo_Operario> TipoOperario_TraerTodos()
        {
            return Dominio.Clases.Tipo_Operario.TraerTodos();
        }

        public static bool TipoOperario_Eliminar(Common.Clases.Tipo_Operario pTipoOperario)
        {
            return Dominio.Clases.Tipo_Operario.Eliminar(pTipoOperario);
        }
        public static bool TipoOperario_Modificar(Common.Clases.Tipo_Operario pTipoOperario)
        {
            return Dominio.Clases.Tipo_Operario.Modificar(pTipoOperario);
        }
        public static Common.Clases.Tipo_Operario TipoOperario_TraerEspecifica (Common.Clases.Tipo_Operario pTipoOperario)
        {
            return Dominio.Clases.Tipo_Operario.TraerEspecifica(pTipoOperario);
        }

        #endregion

        #region Metodos de Pieza-Automovil

        public static bool AgregarPiezaAutomovil(Common.Clases.Automovil pAuto)
        {
            return Dominio.Clases.Automovil.AgregarPiezaAutomovil(pAuto);
        }
        public static bool EliminarPiezaAutomovil(Common.Clases.Automovil pAuto)
        {
            return Dominio.Clases.Automovil.EliminarPiezaAutomovil(pAuto);
        }
        public static List<Common.Clases.Pieza_Automovil> TraerPiezaXAutomovil(Common.Clases.Automovil pAuto)
        {
            return Dominio.Clases.Automovil.TraerPiezasXAutomovil(pAuto);
        }
        public static int CostoXAutomovil(Common.Clases.Automovil pAutomovil)
        {
            return Dominio.Clases.Automovil.CostoXAutomovil(pAutomovil);
        }
        public static int HorasXAutomovil(Common.Clases.Automovil pAutomovil)
        {
            return Dominio.Clases.Automovil.HorasXAutomovil(pAutomovil);
        }
        public static int CantOpXAutomovil(Common.Clases.Automovil pAutomovil)
        {
            return Dominio.Clases.Automovil.CantOpXAutomovil(pAutomovil);
        }
        public static List<Common.Clases.CantTipoXAutomovil> CantTipoXAutomovil(Common.Clases.Automovil pAutomovil)
        {
            return Dominio.Clases.Automovil.CantTipoXAutomovil(pAutomovil);
        }

        #endregion

        #region Metodo de Cuenta
        public static Common.Clases.Cuenta Verificar(Common.Clases.Cuenta pCuenta)
        {
            return Dominio.Clases.Cuenta.Verificar(pCuenta);
        }
        #endregion

        public static List<Common.Clases.Sector_Actividad> TraerTodos_SA()
        {
            return Dominio.Clases.Sector_Actividad.TraerTodos();
        }

        #region Metodo de Trabaja
        public static bool TrabajaAgregar(Common.Clases.Trabaja pTrabaja)
        {
            return Dominio.Clases.Automovil.TrabajaAgregar(pTrabaja);
        }
        public static bool TrabajaEliminar(Common.Clases.Trabaja pTrabaja)
        {
            return Dominio.Clases.Automovil.TrabajaEliminar(pTrabaja);
        }
        public static bool ExisteTrabajo(Common.Clases.Operario op, Common.Clases.Sector_Actividad se, Common.Clases.Automovil auto)
        {
            return Dominio.Clases.Automovil.ExisteTrabajo(op, se, auto);
        }
        public static List<Common.Clases.Trabaja> TraerDatos_Trabaja(Common.Clases.Trabaja pTrabaja)
        {
            return Dominio.Clases.Automovil.TraerDatos(pTrabaja);
        }

        #endregion

    }
}
