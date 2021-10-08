using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess
{
    public class SqlConnectionProvider
    {
        private static string connectionString;

        public static void Init(string connectionString) => SqlConnectionProvider.connectionString = connectionString;

        public static IDbConnection CreateConnection() => new SqlConnection(connectionString);
    }
}
