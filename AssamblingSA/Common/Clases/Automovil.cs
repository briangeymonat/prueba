using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Clases
{
    public class Automovil
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public List<Common.Clases.Pieza_Automovil> PiezasAuto { get; set; }
    }
}
