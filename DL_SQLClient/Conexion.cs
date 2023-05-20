using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DL_SQLClient
{
    public class Conexion
    {
        public static string GetConnection()
        {
            //Data Source =.; Initial Catalog = AAcostaPruebaConexion; Persist Security Info = True; User ID = sa; Password = ***********
            return ConfigurationManager.ConnectionStrings["AAcostaPruebaConexion"].ConnectionString.ToString();
        }
    }
}