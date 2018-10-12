using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Clases
{
    public class Pieza
    {
        public int Cod_pieza { get; set; }
        public string Nom_pieza { get; set; }
        public int Valor_pieza { get; set; }
        public Sector_Actividad SA { get; set; }
    }
}
