using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Clases
{
    public class Tipo_Operario
    {
        public static bool Agregar(Common.Clases.Tipo_Operario pTipoOperario)
        {
            return Persistencia.Clases.Tipo_Operario.Agregar(pTipoOperario);
        }

        public static List<Common.Clases.Tipo_Operario> TraerTodos()
        {
            return Persistencia.Clases.Tipo_Operario.TraerTodos();
        }

        public static bool Eliminar(Common.Clases.Tipo_Operario pTipoOperario)
        {
            return Persistencia.Clases.Tipo_Operario.Eliminar(pTipoOperario);
        }
        public static bool Modificar(Common.Clases.Tipo_Operario pTipoOperario)
        {
            return Persistencia.Clases.Tipo_Operario.Modificar(pTipoOperario);
        }
        public static Common.Clases.Tipo_Operario TraerEspecifica(Common.Clases.Tipo_Operario pTipo)
        {
            return Persistencia.Clases.Tipo_Operario.TraerEspecifica(pTipo);
        }
    }
}
