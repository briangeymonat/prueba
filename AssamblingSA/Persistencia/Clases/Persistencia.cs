using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Persistencia.Clases
{
    public class  Persistencia
    {

        protected static string CadenaDeConexion
        {
            get
            {
                return "Data Source=Brian\\MSSQLSERVER2;Initial Catalog=AssemblingSA;Trusted_Connection=yes";
                //return "Data Source=.;Initial Catalog=AssemblingSA;Trusted_Connection=yes";

            }
        }



    }
}
