using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Dapper;

namespace Blagajna
{
    public static class ConnectionHelper
    {
        public static string GetFirstValueAsString(string query)
        {
            //return ConfigurationManager.ConnectionStrings[name].ConnectionString;
            string name = "CP";

            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings[name].ConnectionString))
            {
                var output = conn.Query<String>(query);
                return output.First();
            }
        }
    }
}
