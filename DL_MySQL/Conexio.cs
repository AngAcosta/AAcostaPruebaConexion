using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DL_MySQL
{
    public class Conexio
    {
        public static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["aacostausuario23"].ConnectionString.ToString();
        }
    }
}