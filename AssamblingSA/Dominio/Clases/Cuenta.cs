using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Clases
{
    public class Cuenta
    {
        public static Common.Clases.Cuenta Verificar(Common.Clases.Cuenta pCuenta)
        {
            return Persistencia.Clases.Cuenta.Verificar(pCuenta);
        }
    }
}
