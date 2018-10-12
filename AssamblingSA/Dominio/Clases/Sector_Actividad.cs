using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Clases
{
    public class Sector_Actividad
    {
        public static List<Common.Clases.Sector_Actividad> TraerTodos()
        {
            return Persistencia.Clases.Sector_Activdad.TraerTodos();
        }
    }
}
