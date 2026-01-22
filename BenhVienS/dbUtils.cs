using System.Data.SqlClient;

namespace BenhVienS
{
    public class dbUtils
    {
        public static string ConnectionString =
            @"Data Source=MSI\SQLPHAT;Initial Catalog=Benhvienv1;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
