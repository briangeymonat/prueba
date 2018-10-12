using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Clases
{
    public class Pieza
    {
        public static bool Agregar(Common.Clases.Pieza pPieza)
        {
            return Persistencia.Clases.Pieza.Agregar(pPieza);
        }

        public static List<Common.Clases.Pieza> TraerTodasPieza()
        {
            return Persistencia.Clases.Pieza.TraerTodasPieza();
        }

        public static bool Eliminar(Common.Clases.Pieza pPieza)
        {
            return Persistencia.Clases.Pieza.Eliminar(pPieza);
        }
        public static bool Modificar(Common.Clases.Pieza pPieza)
        {
            return Persistencia.Clases.Pieza.Modificar(pPieza);
        }
        public static Common.Clases.Pieza TraerEspecifica(Common.Clases.Pieza pPieza)
        {
            return Persistencia.Clases.Pieza.TraerEspecifica(pPieza);
        }

        public static bool ExistePiezaAutomovil(Common.Clases.Automovil pA, Common.Clases.Pieza pP)
        {
            return Persistencia.Clases.Pieza.ExistePiezaAutomovil(pA, pP);
        }


    }
}
