using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Clases
{
    class Operario
    {
        public static bool Agregar(Common.Clases.Operario pOperario)
        {
            return Persistencia.Clases.Operario.Agregar(pOperario);
        }

        public static List<Common.Clases.Operario> TraerTodas()
        {
            return Persistencia.Clases.Operario.TraerTodas();
        }

        public static Common.Clases.Operario TraerEspecifica(Common.Clases.Operario pOperario)
        {
            return Persistencia.Clases.Operario.TraerEspecifica(pOperario);
        }

        public static bool Eliminar(Common.Clases.Operario pOperario)
        {
            return Persistencia.Clases.Operario.Eliminar(pOperario);
        }

        public static bool Modificar(Common.Clases.Operario pOperario)
        {
            return Persistencia.Clases.Operario.Modificar(pOperario);
        }

    }
}

