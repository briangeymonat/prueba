using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Clases
{
    public class Automovil
    {
        public static bool Agregar(Common.Clases.Automovil pAutomovil) 
        {
            return Persistencia.Clases.Automovil.Agregar(pAutomovil);
        }
        public static Common.Clases.Automovil TraerEspecifica_Automovil(Common.Clases.Automovil pAutomovil)
        {
            return Persistencia.Clases.Automovil.TraerEspecifica(pAutomovil);
        }
        public static List<Common.Clases.Automovil> TraerTodas()
        {
            return Persistencia.Clases.Automovil.TraerTodas();
        }
        public static bool Eliminar(Common.Clases.Automovil pAutomovil)
        {
            return Persistencia.Clases.Automovil.Eliminar(pAutomovil);
        }
        public static bool Modificar(Common.Clases.Automovil pAutomovil)
        {
            return Persistencia.Clases.Automovil.Modificar(pAutomovil);
        }


        #region FABRICACION AUTOMOVIL

        public static bool AgregarPiezaAutomovil(Common.Clases.Automovil pAuto)
        {
            return Persistencia.Clases.Automovil.AgregarPiezaAutomovil(pAuto);
        }
        public static bool EliminarPiezaAutomovil(Common.Clases.Automovil pAuto)
        {
            return Persistencia.Clases.Automovil.EliminarPiezaAutomovil(pAuto);
        }
        public static List<Common.Clases.Pieza_Automovil> TraerPiezasXAutomovil(Common.Clases.Automovil pAuto)
        {
            return Persistencia.Clases.Automovil.TraerPiezasXAutomovil(pAuto);
        }
        public static int CostoXAutomovil(Common.Clases.Automovil pAutomovil)
        {
            int costo1 = Persistencia.Clases.Automovil.CostoXAutomovilPieza(pAutomovil);
            int costo2 = Persistencia.Clases.Automovil.CostoXAutomovilOperario(pAutomovil);
            int total = costo1 + costo2;
            return total;
        }
        public static int HorasXAutomovil(Common.Clases.Automovil pAutomovil)
        {
            return Persistencia.Clases.Automovil.HorasXAutomovil(pAutomovil);
        }
        public static int CantOpXAutomovil(Common.Clases.Automovil pAutomovil)
        {
            return Persistencia.Clases.Automovil.CantOpXAutomovil(pAutomovil);
        }
        public static List<Common.Clases.CantTipoXAutomovil> CantTipoXAutomovil(Common.Clases.Automovil pAutomovil)
        {
            return Persistencia.Clases.Automovil.CantTipoXAutomovil(pAutomovil);
        }

        #endregion

        #region TRABAJA
        
        public static bool TrabajaAgregar(Common.Clases.Trabaja pTrabaja)
        {
            return Persistencia.Clases.Automovil.AgregarTrabaja(pTrabaja);
        }
        public static bool TrabajaEliminar(Common.Clases.Trabaja pTrabaja)
        {
            return Persistencia.Clases.Automovil.EliminarTrabaja(pTrabaja);
        }
        public static bool ExisteTrabajo(Common.Clases.Operario op, Common.Clases.Sector_Actividad se, Common.Clases.Automovil auto)
        {
            return Persistencia.Clases.Automovil.ExisteTrabajo(op, se, auto);
        }
        public static List<Common.Clases.Trabaja> TraerDatos(Common.Clases.Trabaja pTrabaja)
        {
            return Persistencia.Clases.Automovil.TraerDatos(pTrabaja);
        }

        #endregion

    }
}
